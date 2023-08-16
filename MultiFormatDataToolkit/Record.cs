namespace MultiFormatDataToolkit;

public class Record
{
    private readonly int _price;
    private readonly string _brandName = "";
    private readonly string _date = "";

    public string Date
    {
        get => _date;
        init
        {
            if (!IsValidDate(value))
            {
                throw new ArgumentException($"Invalid date format: {value}. Expected format: DD.MM.YYYY");
            }

            _date = value;
        }
    }

    public string BrandName
    {
        get => _brandName;
        init
        {
            if (value.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(BrandName), $"BrandName length must be higher than 0, but was {value}");
            }

            _brandName = value;
        }
    }

    public int Price {
        get => _price;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), $"Price must be higher than 0, but was {value}");
            }

            _price = value;
        } 
    }
    private static bool IsValidDate(string date)
    {
        if (string.IsNullOrWhiteSpace(date))
        {
            return false;
        }

        var dateParts = date.Split('.');
    
        if (dateParts.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(dateParts[0], out var day) || !int.TryParse(dateParts[1], out var month) || !int.TryParse(dateParts[2], out var year))
        {
            return false;
        }

        return day is >= 1 and <= 31 && month is >= 1 and <= 12;
    }
}
