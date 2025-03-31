using System;
using System.IO.Ports;
using System.Net.Mime;
using System.Threading;
namespace In12BClockService;

class ClockApiClient
{
    private SerialPort? _serialPort;
    private bool _continue;

    public void StartCommunication(string comPort, int baudRate)
    {
        _serialPort = new SerialPort
        {
            PortName = comPort,
            BaudRate = baudRate,
            Parity = Parity.None,
            DataBits = 8,
            StopBits = StopBits.One,
            Handshake = Handshake.None,
            ReadTimeout = 500,
            WriteTimeout = 500
        };

        try
        {
            _serialPort.Open();
            _continue = true;
            
            while (_continue)
            {
                _serialPort.WriteLine("1111111100end.\n");
                Task.Delay(200);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                Console.WriteLine("Port closed");
            }
        }
    }

    public void Initialize()
    {
        string configs = TxtHandler.ReadTxt(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs"));
        string comPort = configs.Split(' ')[0];
        
        if (!int.TryParse(configs.Split(' ')[1], out int baudRate))
        {
            Console.WriteLine("couldn't parse baud rate");
        }
        
        
        ClockApiClient bluetooth = new ClockApiClient();
        bluetooth.StartCommunication(comPort, baudRate);
    }
}