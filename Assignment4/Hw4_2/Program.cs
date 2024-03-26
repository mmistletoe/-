using System;
using System.Timers;

public class Clock
{
    // 定义一个委托，用于处理Tick事件  
    public delegate void TickEventHandler(object source, EventArgs e);
    // 定义一个事件，当闹钟走时触发  
    public event TickEventHandler Tick;

    // 定义一个委托，用于处理Alarm事件  
    public delegate void AlarmEventHandler(object source, EventArgs e);
    // 定义一个事件，当闹钟响铃时触发  
    public event AlarmEventHandler Alarm;

    // 创建一个计时器来模拟时钟的嘀嗒声  
    private System.Timers.Timer _tickTimer;
    // 闹钟响铃时间（假设是60秒后）  
    private int _alarmTimeInSeconds = 60;
    // 当前时间（秒）  
    private int _currentTimeInSeconds = 0;

    public Clock()
    {
        // 初始化计时器，间隔为1秒（1000毫秒）  
        _tickTimer = new System.Timers.Timer(1000);
        _tickTimer.Elapsed += OnTimedEvent;
        // 开始计时器  
        _tickTimer.Enabled = true;
        _tickTimer.AutoReset = true;
    }

    public int CurrentTimeInSeconds
    {
        get { return _currentTimeInSeconds; }
    }

    // 当计时器触发时调用的方法  
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        _currentTimeInSeconds++;
        // 触发Tick事件  
        OnTick(EventArgs.Empty);

        // 检查是否到达响铃时间  
        if (_currentTimeInSeconds >= _alarmTimeInSeconds)
        {
            // 停止计时器  
            _tickTimer.Stop();
            // 触发Alarm事件  
            OnAlarm(EventArgs.Empty);
        }
    }

    // 保护型方法，用于触发Tick事件  
    protected virtual void OnTick(EventArgs e)
    {
        Tick?.Invoke(this, e);
        Console.WriteLine("嘀嗒...");
    }

    // 保护型方法，用于触发Alarm事件  
    protected virtual void OnAlarm(EventArgs e)
    {
        Alarm?.Invoke(this, e);
        Console.WriteLine("闹钟响了！");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Clock clock = new Clock();

        // 订阅Tick事件  
        clock.Tick += (sender, e) =>
        {
            Console.WriteLine("当前时间（秒）: " + clock.CurrentTimeInSeconds);
        };

        // 订阅Alarm事件  
        clock.Alarm += (sender, e) =>
        {
            Console.WriteLine("该起床了！");
        };

        Console.WriteLine("按任意键退出...");
        Console.ReadKey();
    }
}