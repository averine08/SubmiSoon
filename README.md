1. Install .NET SDK (versi 8), Node.js LTS (Latest) , dan SQL Server(using SSMS)

2. Clone/Extract project ini
3. /V:\SubmiSoon\backend\SubmiSoonApi (Backend)
- Run ```cd backend```
- set connection string di appsettings.json
- Run ```dotnet restore```
- Run ```dotnet ef database update```
- Run ```dotnet run```

4. V:\SubmiSoon\frontend\SubmiSoon-FrontEnd (Frontend)
- Run ```cd frontend```
- Run ```npm install```, make sure npm version is 10 at max (to ensure tailwind is running) | note: can downgrade npm version locally by run "npm install npm@10 --save-dev" on the folder project
- change baseURL in axios.ts to http URL backend
- Run ```npm run dev```
