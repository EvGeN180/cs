using System;

public interface IRemoteControl
{
    string BrandName { get; }
    void PowerOn();
    void PowerOff();
    void VolumeUp();
    void VolumeDown();
    void ChangeChannel(int channelNumber);
}

public class Television : IRemoteControl
{
    private bool isPoweredOn = false;
    private int volume = 5;
    private int channel = 1;

    public string BrandName => "SmartTV Remote";

    public void PowerOn()
    {
        isPoweredOn = true;
        Console.WriteLine("Television is now ON.");
    }

    public void PowerOff()
    {
        isPoweredOn = false;
        Console.WriteLine("Television is now OFF.");
    }

    public void VolumeUp()
    {
        if (isPoweredOn)
        {
            volume++;
            Console.WriteLine($"Volume increased. Current volume: {volume}");
        }
    }

    public void VolumeDown()
    {
        if (isPoweredOn)
        {
            volume--;
            Console.WriteLine($"Volume decreased. Current volume: {volume}");
        }
    }

    public void ChangeChannel(int channelNumber)
    {
        if (isPoweredOn)
        {
            channel = channelNumber;
            Console.WriteLine($"Channel changed to: {channel}");
        }
    }
}

public class SoundSystem : IRemoteControl
{
    private bool isPoweredOn = false;
    private int volume = 10;

    public string BrandName => "Sound";

    public void PowerOn()
    {
        isPoweredOn = true;
        Console.WriteLine("Sound System is now ON.");
    }

    public void PowerOff()
    {
        isPoweredOn = false;
        Console.WriteLine("Sound System is now OFF.");
    }

    public void VolumeUp()
    {
        if (isPoweredOn)
        {
            volume += 2;
            Console.WriteLine($"Sound System volume increased by 2. Current volume: {volume}");
        }
    }

    public void VolumeDown()
    {
        if (isPoweredOn)
        {
            volume -= 2;
            Console.WriteLine($"Sound System volume decreased by 2. Current volume: {volume}");
        }
    }

    public void ChangeChannel(int channelNumber)
    {
        if (isPoweredOn)
        {
            Console.WriteLine($"Sound System is tuning to input source: {channelNumber}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IRemoteControl tvRemote = new Television();
        Console.WriteLine($"Using {tvRemote.BrandName}:");
        tvRemote.PowerOn();
        tvRemote.VolumeUp();
        tvRemote.ChangeChannel(5);
        tvRemote.PowerOff();

        Console.WriteLine("\n-------------------------------\n");

        IRemoteControl soundSystemRemote = new SoundSystem();
        Console.WriteLine($"Using {soundSystemRemote.BrandName}:");
        soundSystemRemote.PowerOn();
        soundSystemRemote.VolumeUp();
        soundSystemRemote.VolumeDown();
        soundSystemRemote.ChangeChannel(2);
        soundSystemRemote.PowerOff();
    }
}
