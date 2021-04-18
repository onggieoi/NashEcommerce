using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Exceptions;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ViewModelShare.Product;

namespace backend.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private ILogger<ProductRepository> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IBlobService _blobService;

        public ProductRepository(ILogger<ProductRepository> logger,
            IMapper mapper,
            IBlobService blobService,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _blobService = blobService;
        }
        public async Task<ProductRespone> GetProduct(int productId)
        {
            var product = await _context.Products
                .Include(products => products.Category)
                .Where(product => product.ProductId.Equals(productId))
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (product == null)
            {
                throw new NotFoundException($"{productId} Not Found");
            }

            var productRes = _mapper.Map<ProductRespone>(product);

            return productRes;
        }

        public async Task<IEnumerable<ProductRespone>> GetProducts()
        {
            var products = await _context.Products
                .Include(products => products.Category)
                .AsNoTracking()
                .ToListAsync();

            var productsRes = _mapper.Map<IEnumerable<ProductRespone>>(products);

            return productsRes;
        }

        public async Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products
                .Where(product => product.CategoryId.Equals(categoryId))
                .AsNoTracking()
                .ToListAsync();

            var productsRes = _mapper.Map<IEnumerable<ProductRespone>>(products);

            return productsRes;
        }

        public async Task<ProductRespone> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                throw new NotFoundException($"{productId} Not Found");
            }

            product.IsDelete = true;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(product);

            return productRes;
        }

        public async Task<ProductRespone> CreateProduct(ProductRequest productReq)
        {
            if (productReq is null)
            {
                throw new Exception("Null");
            }

            if (productReq.ImageFile is not null)
            {
                var imageUri = await UploadImageAsync(productReq.ImageFile);
                productReq.Image = imageUri;
            }

            var product = _mapper.Map<Product>(productReq);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(product);

            return productRes;
        }

        public async Task<ProductRespone> UpdateProduct(int productId, ProductRequest productReq)
        {
            var existProduct = await _context.Products.FindAsync(productId);

            if (existProduct == null)
            {
                throw new NotFoundException($"Product id {productId} not found");
            }

            if (productReq.ImageFile is not null)
            {
                var imageUri = await UploadImageAsync(productReq.ImageFile);
                productReq.Image = imageUri;
            }

            _context.Entry<Product>(existProduct).CurrentValues.SetValues(productReq);

            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(existProduct);

            return productRes;
        }

        private async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadFileResult = await _blobService.UploadFileBlobAsync("firstcontainer", file.OpenReadStream(),
                        file.ContentType,
                        $"{Guid.NewGuid()}");

            return uploadFileResult.AbsoluteUri;
        }
    }
}