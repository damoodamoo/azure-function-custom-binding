# Azure Functions Custom Binding Sample

This repo contains a few sample projects to demonstrate the architecture and plumbing needed when writing a custom binding in Azure Functions v2. It also contains sample implementation functions written in:
- C#
- JavaScript
- Java

Using this as a starting point should help you understand what's going on, and maybe provide a launch pad for your own project.

> **NOTE**: The code provided here is sample code, please use as reference only and don't just copy straight into production. It has no warranty.

## General Idea
The binding is (and has to be) written in C#. The project should make it clear where the hooks are for you to get data *from* a function (output binding), and supply data *to* a function (input binding).

Bindings are usually referenced in a .csproj file by Nuget package - but it turns out you can also reference local projects too, which is what happens here. For instance, in the JS function `extensions.csproj`, you'll see:
```XML
 <ItemGroup>
    <ProjectReference Include="..\DummyBinding\DummyBinding.csproj" />
  </ItemGroup>
```

## If you're using a JS function with Core Tools...
Make sure to run:
```JavaScript
func extensions sync
```
This will build the binding project and bring across the dlls - caught me out for a while.

## Huge thanks to...
One reason I built this sample is to make it clearer how to put these things together, and big thanks to these guys for helping me understand it. Would recommend reading the following...
- Jason Roberts - http://dontcodetired.com/blog/post/Creating-Custom-Azure-Functions-Bindings
- Jan de Vries - https://jan-v.nl/post/create-your-own-custom-bindings-with-azure-functions
