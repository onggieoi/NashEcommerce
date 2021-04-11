import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { decrement, increment } from 'src/redux/ducks/counter';
import { getTodos } from 'src/redux/ducks/todo';

const Home = () => {
  const dispatch = useDispatch();

  const count = useSelector((state: any) => state.counter.count);
  const todos = useSelector((state: any) => state.todo.todos);

  console.log(todos);

  const plusHandle = () => {
    dispatch(increment());
  };

  const minusHandle = () => {
    dispatch(decrement());
  }

  useEffect(() => {
    dispatch(getTodos());
  }, []);

  return (
    <div>
      <div>Home</div>

      <div className='flex'>
        <button onClick={minusHandle}>Minus</button>
        <div className='mx-5'>{count}</div>
        <button onClick={plusHandle} >Plus</button>
      </div>
    </div>
  )
};

export default Home;