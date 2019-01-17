dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.2/publish

docker build -t schedule-quik-image ./bin/release/netcoreapp2.2/publish

docker tag schedule-quik-image registry.heroku.com/schedulequik-api/web

docker push registry.heroku.com/schedulequik-api/web

heroku container:release web -a schedulequik-api