# NashEcommerce
Stage 1 Challenge

---

## Architecture

- backend: **api** dotnet5 - **oauth** identity server - **ORM** EF core
- client: dotnet5 mvc razor 
- admin: reactjs - typescript - tailwind scss [Codebase](https://github.com/onggieoi/Codebase-Reactjs)
- database: MSSQL

![Architecture](img4README/architecture.png)

---

## OAuth Flows

### Proof Key for Code Exchange by OAuth Public Clients (PKCE)
<pre>
+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+
| End Device (e.g., Smartphone)  |
|                                |
| +-------------+   +----------+ | (6) Access Token  +----------+
| |Legitimate   |   | Malicious|<--------------------|          |
| |OAuth 2.0 App|   | App      |-------------------->|          |
| +-------------+   +----------+ | (5) Authorization |          |
|        |    ^          ^       |        Grant      |          |
|        |     \         |       |                   |          |
|        |      \   (4)  |       |                   |          |
|    (1) |       \  Authz|       |                   |          |
|   Authz|        \ Code |       |                   |  Authz   |
| Request|         \     |       |                   |  Server  |
|        |          \    |       |                   |          |
|        |           \   |       |                   |          |
|        v            \  |       |                   |          |
| +----------------------------+ |                   |          |
| |                            | | (3) Authz Code    |          |
| |     Operating System/      |<--------------------|          |
| |         Browser            |-------------------->|          |
| |                            | | (2) Authz Request |          |
| +----------------------------+ |                   +----------+
+~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+
</pre>

### Protocol Flow
<pre>
                                          +-------------------+
                                          |   Authz Server    |

+--------+                                | +---------------+ |
|        |--(A)- Authorization Request ---->|               | |
|        |       + t(code_verifier), t_m  | | Authorization | |
|        |                                | |    Endpoint   | |
|        |<-(B)---- Authorization Code -----|               | |
|        |                                | +---------------+ |
| Client |                                |                   |
|        |                                | +---------------+ |
|        |--(C)-- Access Token Request ---->|               | |
|        |          + code_verifier       | |    Token      | |
|        |                                | |   Endpoint    | |
|        |<-(D)------ Access Token ---------|               | |
+--------+                                | +---------------+ |
                                          +-------------------+
</pre>
