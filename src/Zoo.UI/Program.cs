using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Zoo;

namespace Zoo.UI;

static class Program
{
    static ZooCoreService _service = null!;

    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IVetClinic, VetClinic>();
        services.AddSingleton<IContactZooRule, ContactZooRule>();
        services.AddSingleton<IInventoryNumberGenerator, InventoryNumberGenerator>();
        services.AddSingleton<ZooCoreService>();
        using var provider = services.BuildServiceProvider();
        _service = provider.GetRequiredService<ZooCoreService>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1 Добавить животное");
            Console.WriteLine("2 Добавить вещь");
            Console.WriteLine("3 Количество животных");
            Console.WriteLine("4 Общая еда в день (кг)");
            Console.WriteLine("5 Кандидаты в контактный зоопарк");
            Console.WriteLine("6 Отчет по инвентарю");
            Console.WriteLine("0 Выход");
            Console.Write("> ");
            var choice = Console.ReadLine();

            if (choice == "0") return;
            if (choice == "1") AddAnimal();
            else if (choice == "2") AddThing();
            else if (choice == "3") ShowAnimalCount();
            else if (choice == "4") ShowAllFood();
            else if (choice == "5") ShowContactZooCandidates();
            else if (choice == "6") ShowReport();
        }
    }

    static void AddAnimal()
    {
        var species = _service.GetSpiciesNames();
        if (species.Count == 0) { Console.WriteLine("Нет доступных видов."); return; }

        var selected = SelectFrom(species.Keys, "Вид");
        if (selected == null) return;

        var specs = species[selected].GetSpecs();
        var values = ReadValues(specs);
        var res = _service.AddAnimal(selected, values);
        Console.WriteLine(res.Success ? "OK" : $"Ошибка: {res.Error}");
    }

    static void AddThing()
    {
        var types = _service.GetTypesNames();
        if (types.Count == 0) { Console.WriteLine("Нет доступных типов."); return; }

        var selected = SelectFrom(types.Keys, "Тип");
        if (selected == null) return;

        var specs = types[selected].GetSpecs();
        var values = ReadValues(specs);
        var res = _service.AddThing(selected, values);
        Console.WriteLine(res.Success ? "OK" : $"Ошибка: {res.Error}");
    }

    static void ShowAnimalCount()
    {
        Console.WriteLine(_service.GetAnimalCount());
    }

    static void ShowAllFood()
    {
        var res = _service.GetAllFoodAmount();
        Console.WriteLine(res.Success ? res.Number.ToString() : $"Ошибка: {res.Error}");
    }

    static void ShowContactZooCandidates()
    {
        var res = _service.ContactZooCandidates();
        if (!res.Success) { Console.WriteLine(res.Error); return; }
        foreach (var a in res.Animals) Console.WriteLine(a.ToString());
    }

    static void ShowReport()
    {
        var res = _service.GetReport();
        if (!res.Success) { Console.WriteLine(res.Error); return; }
        foreach (var line in res.Report) Console.WriteLine(line);
    }

    static string? SelectFrom(IEnumerable<string> items, string title)
    {
        var list = new List<string>(items);
        for (int i = 0; i < list.Count; i++) Console.WriteLine($"{i + 1} {list[i]}");
        Console.Write($"{title} #: ");
        if (!int.TryParse(Console.ReadLine(), out var idx)) return null;
        if (idx < 1 || idx > list.Count) return null;
        return list[idx - 1];
    }

    static Dictionary<string, string> ReadValues(object[] parameters)
    {
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var p in parameters)
        {
            var name = (string)p.GetType().GetProperty("Name")!.GetValue(p)!;
            var type = (string)p.GetType().GetProperty("TypeHint")!.GetValue(p)!;
            var desc = (string)p.GetType().GetProperty("Description")!.GetValue(p)!;
            Console.Write($"{name} ({type}) - {desc}: ");
            var v = Console.ReadLine() ?? "";
            dict[name] = v;
        }
        return dict;
    }
}