﻿using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tanks = GetTanks();
            var units = GetUnits();
            var factories = GetFactories();
            Console.WriteLine($"Количество резервуаров: {tanks.Length}, установок: {units.Length}");

            var foundUnit = FindUnit(units, tanks, "Резервуар 2");
            var factory = FindFactory(factories, foundUnit);

            Console.WriteLine($"Резервуар 2 принадлежит установке {foundUnit.Name} и заводу {factory.Name}");

            var totalVolume = GetTotalVolume(tanks);
            Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

            Console.Write("Введите наименование резервуара для поиска: ");
            string searchTankName = Console.ReadLine();
            var searchedTank = FindTankByName(tanks, searchTankName);
            if (searchedTank != null)
            {
                Console.WriteLine($"Резервуар {searchedTank.Name} найден. Объем: {searchedTank.Volume}");
            }
            else
            {
                Console.WriteLine("Резервуар не найден.");
            }
        }

        // реализуйте этот метод, чтобы он возвращал массив резервуаров, согласно приложенным таблицам
        // можно использовать создание объектов прямо в C# коде через new, или читать из файла (на своё усмотрение)
        public static Tank[] GetTanks()
        {
            return new Tank[]
               {
                new Tank  {Id = 1, Name = "Резервуар 1", Description = "Надземный-вертикальный", Volume = 1500, MaxVolume = 2000, UnitId = 1 } ,
                new Tank  {Id = 2, Name = "Резервуар 2", Description = "Надземный-горизонтальный", Volume = 2500, MaxVolume = 3000, UnitId = 1 } ,
                new Tank  {Id = 3, Name = "Дополнительный резервуар 24", Description = "Надземный-горизонтальный", Volume = 3000, MaxVolume = 3000, UnitId = 2 } ,
                new Tank  {Id = 4, Name = "Резервуар 35", Description = "Надземный-вертикальный", Volume = 3000, MaxVolume = 3000, UnitId = 2 },
                new Tank  {Id = 5, Name = "резервуар 47", Description = "Подземный-двустенный", Volume = 4000, MaxVolume = 5000, UnitId = 2 },
                new Tank  {Id = 6, Name = "Резервуар 256", Description = "Подводный", Volume = 500, MaxVolume = 500, UnitId = 3 }
               };
        }
        // реализуйте этот метод, чтобы он возвращал массив установок, согласно приложенным таблицам
        public static Unit[] GetUnits()
        {
            return new Unit[]
                {
                new Unit  {Id = 1, Name = "ГФУ-2", Description = "Газофракционирующая установка", FactoryId = 1 } ,
                new Unit  {Id = 2, Name = "АВТ-6", Description = "Атмосферно-вакуумная трубчатка", FactoryId = 1 },
                new Unit  {Id = 3, Name = "АВТ-10", Description = "Атмосферно-вакуумная трубчатка", FactoryId = 2 }
                };
        }
        // реализуйте этот метод, чтобы он возвращал массив заводов, согласно приложенным таблицам
        public static Factory[] GetFactories()
        {
            return new Factory[]
                 {
                    new Factory  {Id = 1, Name = "НПЗ№1", Description = "Первый Нефтеперерабатывающий завод" } ,
                    new Factory  {Id = 2, Name = "НПЗ№2", Description = "Второй Нефтеперерабатывающий завод" }
                 };
        }

        // реализуйте этот метод, чтобы он возвращал установку (Unit), которой
        // принадлежит резервуар (Tank), найденный в массиве резервуаров по имени
        // учтите, что по заданному имени может быть не найден резервуар
        public static Unit? FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            foreach (var tank in tanks)
            {
                if (tank.Name == tankName)
                {
                    foreach (var unit in units)
                    {
                        if (unit.Id == tank.UnitId)
                        {
                            return unit;
                        }
                    }
                }
            }
            return null;
        }

        // реализуйте этот метод, чтобы он возвращал объект завода, соответствующий установке
         public static Factory? FindFactory(Factory[] factories, Unit unit)
        {
            foreach (var factory in factories)
            {
                if (factory.Id == unit.FactoryId)
                {
                    return factory;
                }
            }
            return null;
        }

        // реализуйте этот метод, чтобы он возвращал суммарный объем резервуаров в массиве
       

        public static Tank? FindTankByName(Tank[] tanks, string tankName)
        {
            foreach (var tank in tanks)
            {
                if (tank.Name.ToLower() == tankName.ToLower())
                {
                    return tank;
                }
            }
            return null;
        }

        public static int GetTotalVolume(Tank[] tanks)
        {
            int totalVolume = 0;
            foreach (var tank in tanks)
            {
                totalVolume += tank.Volume;
            }
            return totalVolume;
        }
        public class Unit
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int FactoryId { get; set; }
        }

        public class Factory
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class Tank
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int Volume { get; set; }
            public int MaxVolume { get; set; }
            public int UnitId { get; set; }
        }
    }
}
