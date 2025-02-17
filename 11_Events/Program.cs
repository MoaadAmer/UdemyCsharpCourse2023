
//Observer design pattern

//var goldPrice = new GoldPrice();
//var emailObserver = new EmailObserver();
//goldPrice.Subscribe(emailObserver);
//goldPrice.UpdatePrice();




//public interface IObservable<T>
//{
//    void Subscribe(IObserver<T> observer);
//    void Unsubscribe(IObserver<T> observer);
//    void Notify();
//}



//public class GoldPrice : IObservable<decimal>
//{
//    public decimal Price { get; private set; }
//    private readonly List<IObserver<decimal>> _observers = [];

//    public void Notify()
//    {
//        foreach (var observer in _observers)
//        {
//            observer.Update(Price);
//        }
//    }

//    public void Subscribe(IObserver<decimal> observer)
//    {
//        _observers.Add(observer);
//    }

//    public void Unsubscribe(IObserver<decimal> observer)
//    {
//        _observers.Remove(observer);
//    }

//    public void UpdatePrice()
//    {
//        Price = new Random().Next(1000, 5000);

//        Notify();
//    }
//}

//public interface IObserver<T>
//{
//    void Update(T value);
//}

//public class EmailObserver : IObserver<decimal>
//{
//    public void Update(decimal value)
//    {
//        Console.WriteLine($"Email: {value}");
//    }
//}

//Achieve the same result using events

//public delegate void OnBalanceDecreased(decimal balance);

//public class BankAccount
//{
//    public decimal Balance { get; private set; }
//    public BankAccount(decimal initialBalance)
//    {
//        Balance = initialBalance;
//    }
//    public event OnBalanceDecreased OnBalanceDecreased;

//    public void DecreaseBalance(decimal price)
//    {
//        //your code goes here
//        Balance -= price;
//        OnBalanceDecreased?.Invoke(price);
//    }

//}

//public class User
//{
//    public decimal Funds { get; private set; }

//    public User(decimal cash, decimal moneyInBank)
//    {
//        Funds = cash + moneyInBank;
//    }

//    public void ReduceFunds(decimal balanceReduced)
//    {
//        Funds -= balanceReduced;
//    }
//}


var weatherDataAggregator = new WeatherDataAggregator();
var weatherStation = new WeatherStation();
weatherStation.WeatherMeasured += weatherDataAggregator.GetNotifiedAboutNewData;
var weatherBaloon = new WeatherBaloon();
weatherBaloon.WeatherMeasured += weatherDataAggregator.GetNotifiedAboutNewData;

weatherStation.Measure();
weatherBaloon.Measure();

public record struct WeatherData(int? Temperature, int? Humidity);

public class WeatherDataAggregator
{
    public IEnumerable<WeatherData> WeatherHistory => _weatherHistory;
    private List<WeatherData> _weatherHistory = new();

    public void GetNotifiedAboutNewData(object? sender,WeatherDataEventArgs eventArgs)
    {
       _weatherHistory.Add(new WeatherData(eventArgs.WeatherData.Temperature, eventArgs.WeatherData.Humidity));
    }
}


public class WeatherStation
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int temperature = 25;

        OnWeatherMeasured(temperature);
    }

    private void OnWeatherMeasured(int temperature)
    {
        WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(temperature, null)));
    }
}

public class WeatherBaloon
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int humidity = 50;

        OnWeatherMeasured(humidity);
    }

    private void OnWeatherMeasured(int humidity)
    {
        WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(null, humidity)));
    }
}

public class WeatherDataEventArgs : EventArgs
{
    public WeatherData WeatherData { get; }

    public WeatherDataEventArgs(WeatherData weatherData)
    {
        WeatherData = weatherData;
    }
}

