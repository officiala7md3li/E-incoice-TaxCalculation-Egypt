# NuGet Publishing Instructions

## Package Creation
```bash
dotnet pack --configuration Release --output ./nupkg
```

## Publishing to NuGet.org
```bash
dotnet nuget push ./nupkg/*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```