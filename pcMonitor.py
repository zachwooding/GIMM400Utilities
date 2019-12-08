import wmi
import pyfirmata
import time
import serial

w = wmi.WMI(namespace="root\OpenHardwareMonitor")
ser = serial.Serial('COM3', 9600)
while True:
	temperature_infos = w.Sensor()
	c = ""
	t = ""
	for sensor in temperature_infos:
		
		if (sensor.Name==u'CPU Package' and sensor.SensorType==u'Temperature'):
			t = str(sensor.Value)
			
			
		if(sensor.Name==u'CPU Total' and sensor.SensorType==u'Load'):
			
			c = "{:.2f}".format(sensor.Value)
	
	s = t + "_" + c + "_"
	ser.write(s.encode())

	time.sleep(0.1)
	#ser.write(('Hello World'.encode()));

def getHardwareData():
	temperature_infos = w.Sensor()
	for sensor in temperature_infos:
		if sensor.SensorType==u'Temperature':
			print(sensor.Name)
			ser.write(sensor.Value)


#getHardwareData()