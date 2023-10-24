#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# cd TTMS-Api/src
# docker build -t ttms -f TTMS.Api/Dockerfile .
# docker run --rm -d -p 8082:80 --name ttms ttms 本项目暂由容器的80端口映射到主机的8082端口，再由nginx做反向代理

# base阶段
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base # mcr.microsoft.com/dotnet/aspnet:6.0 用于运行程序
WORKDIR /app # 工作目录
EXPOSE 80 # 监听http端口
EXPOSE 443 # 监听https端口

# build阶段
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build # mcr.microsoft.com/dotnet/sdk:6.0 用于构建程序
WORKDIR /src # 工作目录
COPY ["TTMS.Api/TTMS.Api.csproj", "TTMS.Api/"] # 将/src/TTMS.Api/TTMS.Api.csproj复制到容器的/src/TTMS.Api目录下
COPY ["TTMS.Service/TTMS.Service.csproj", "TTMS.Service/"]
COPY ["TTMS.Repository/TTMS.Repository.csproj", "TTMS.Repository/"]
COPY ["TTMS.DTO/TTMS.DTO.csproj", "TTMS.DTO/"]
COPY ["TTMS.Domain/TTMS.Domain.csproj", "TTMS.Domain/"]
COPY ["TTMS.Enums/TTMS.Enums.csproj", "TTMS.Enums/"]
RUN dotnet restore "TTMS.Api/TTMS.Api.csproj" # 还原项目的NuGet依赖项
COPY . . # 将当前目录下的所有文件复制到容器内的当前目录(src目录下)
WORKDIR "/src/TTMS.Api" # 切换工作目录
RUN dotnet build "TTMS.Api.csproj" -c Release -o /app/build # 在容器内构建Release版本并放到/app/build目录下

# publish阶段
FROM build AS publish
RUN dotnet publish "TTMS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false # 在容器内发布Release版本并放到/app/publish目录下

# final阶段
FROM base AS final
WORKDIR /app # 工作目录
COPY --from=publish /app/publish . # 从publish阶段的镜像中/app/publish目录下的文件复制到当前目录下
ENTRYPOINT ["dotnet", "TTMS.Api.dll"] # 容器启动时运行程序
