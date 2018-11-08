# PlayGit

## Instructions to contributors
* Install **dotnet core**

    https://www.microsoft.com/net/download

* Install sox

``` sh
brew install sox
```

* Run with test data file

```
cat data.txt | dotnet run
```

## Create an executable 

``` sh
dotnet publish -c Release --framework netcoreapp2.1 --runtime osx-x64
```