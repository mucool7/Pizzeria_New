# Pizzeria_New


Client is website written in Angular 10.
Serve is Api project written in .net core 3.1 webapi

For Demo : http://52.15.217.2:8090/


Requirements
1. Angular 10
2. Nodejs
3. CMD
4. Windows 10
5. .Net Core 3.1
6. VS Studio 2019


============= How to run Serve (Api) Project =====================

1. After Cloning repository open the Solution present at Server\Pizzeria_api location.
2. Install all dependency.
3. run the application by pressing F5.

Note: After running the app please copy the port no on which your api is runing as this is required for the angular project

=============  How to run client project   ==================

1. After Cloning repository and navigate to Client=>pizzeria and run code . to open vscode with project.
2. Navigate to Client\pizzeria\src\app\Shared\Providers\http.service.ts file and open it on vscode.
3. update END_POINT with the domain/ipaddress and port no which is used by your api project.currently it is set to 'http://52.15.217.2/api/'
4. npm install to install all the packages
5. ng serve command to run the app on localhost:4200.




