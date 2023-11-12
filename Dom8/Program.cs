using System;

class SquareArray
{
    private int[] array;

    public SquareArray(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value * value;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Пример работы с индексатором:");
        UseIndexer();

        Console.WriteLine("\nПример расчета коммунальных платежей:");
        CalculateUtilityPayments();

        Console.ReadLine();
    }

    static void UseIndexer()
    {
        SquareArray myArray = new SquareArray(5);

        myArray[0] = 2;
        myArray[1] = 3;
        myArray[2] = 4;
        myArray[3] = 5;
        myArray[4] = 6;

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Элемент {i}: {myArray[i]}");
        }
    }

    static void CalculateUtilityPayments()
    {
        Console.WriteLine("Введите данные для расчета коммунальных платежей:");

        // Ввод данных
        Console.Write("Площадь помещения (м2): ");
        double area = Convert.ToDouble(Console.ReadLine());

        Console.Write("Количество проживающих: ");
        int numberOfResidents = Convert.ToInt32(Console.ReadLine());

        Console.Write("Сезон (введите 'осень' или 'зима'): ");
        string season = Console.ReadLine().ToLower();

        Console.Write("Наличие льгот (ветеран труда - 'да'/'нет'): ");
        bool veteranOfWork = Console.ReadLine().ToLower() == "да";

        Console.Write("Наличие льгот (ветеран войны - 'да'/'нет'): ");
        bool warVeteran = Console.ReadLine().ToLower() == "да";

        double heatingRate = GetHeatingRate(season);
        double waterRate = 20; // пример, замените на реальный тариф
        double gasRate = 30; // пример, замените на реальный тариф
        double repairRate = 5; // пример, замените на реальный тариф

        double heatingCharge = area * heatingRate;
        double waterCharge = numberOfResidents * waterRate;
        double gasCharge = numberOfResidents * gasRate;
        double repairCharge = area * repairRate;

        double heatingDiscount = GetVeteranDiscount(heatingCharge, veteranOfWork);
        double waterDiscount = GetVeteranDiscount(waterCharge, veteranOfWork);
        double gasDiscount = GetVeteranDiscount(gasCharge, veteranOfWork);

        double totalCharge = heatingCharge + waterCharge + gasCharge + repairCharge;
        double totalDiscount = heatingDiscount + waterDiscount + gasDiscount;

        Console.WriteLine("\nТаблица коммунальных платежей:");
        Console.WriteLine("| Вид платежа        | Начислено | Льготная скидка | Итого   |");
        Console.WriteLine("|---------------------|-----------|------------------|---------|");
        PrintRow("Отопление", heatingCharge, heatingDiscount);
        PrintRow("Вода", waterCharge, waterDiscount);
        PrintRow("Газ", gasCharge, gasDiscount);
        PrintRow("Текущий ремонт", repairCharge, 0);

        Console.WriteLine("|---------------------|-----------|------------------|---------|");
        PrintRow("Итого", totalCharge, totalDiscount);
    }

    static double GetHeatingRate(string season)
    {
        if (season == "осень")
            return 0.05; // пример, замените на реальный тариф на отопление осенью
        else if (season == "зима")
            return 0.1; // пример, замените на реальный тариф на отопление зимой
        else
            return 0;
    }

    static double GetVeteranDiscount(double charge, bool isVeteran)
    {
        if (isVeteran)
            return 0.5 * charge; // 50% скидка для ветеранов
        else
            return 0;
    }

    static void PrintRow(string paymentType, double charge, double discount)
    {
        double total = charge - discount;
        Console.WriteLine($"| {paymentType,-20} | {charge,9:F2} | {discount,16:F2} | {total,7:F2} |");
    }
}
