using System;
using System.Device.Gpio;
using System.Threading;


/*
 * ssh admin@192.168.68.167
 publish, then scp -r C:/projects/Blink2/bin/Release/net6.0/publish/* admin@192.168.68.167:~/projects/Blink2/
 */

Console.WriteLine("Blinking LED. Press Ctrl+C to end.");
int pin = 27;
using var controller = new GpioController();
controller.OpenPin(pin, PinMode.Output);
bool ledOn = true;
while (true)
{
    controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
    Thread.Sleep(2000);
    ledOn = !ledOn;
}