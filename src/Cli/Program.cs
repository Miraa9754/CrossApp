using Core.Dto;
using Core.Import;

string path = args.Length > 0
    ? args[0]
    : Path.Combine("data", "sample.csv");

if (!File.Exists(path))
{
    Console.WriteLine($"Файл не знайдено: {Path.GetFullPath(path)}");
    return 1;
}

try
{
    ImportResult<ProductDto> result = ProductCsvImporter.Load(path);

    Console.WriteLine($"Завантажено записів: {result.Items.Count}");
    Console.WriteLine();

    foreach (ProductDto product in result.Items.Take(5))
    {
        Console.WriteLine(
            $" {product.Id,-6} {product.Sku,-10} " +
            $"{product.Name,-32} {product.Quantity,5} {product.Unit}");
    }

    if (result.Errors.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine($"Пропущено рядків: {result.Errors.Count}");

        foreach (string error in result.Errors)
        {
            Console.WriteLine($" ! {error}");
        }
    }
}
catch (IOException ex)
{
    Console.WriteLine($"Помилка читання файлу: {ex.Message}");
    return 1;
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine($"Немає дозволу на читання файлу: {Path.GetFullPath(path)}");
    return 1;
}

return 0;
