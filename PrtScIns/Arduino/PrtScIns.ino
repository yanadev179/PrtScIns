int btnPrtSc = 8;
int btnIns = 9;

void setup() 
{
  Serial.begin(9600);
  pinMode(btnPrtSc, INPUT_PULLUP);  
  pinMode(btnIns, INPUT_PULLUP);  
}

void loop() 
{
    SerialPrintln(btnPrtSc, "PrtSc");
    SerialPrintln(btnIns, "Ins");
}

void SerialPrintln(int btn,String printStr)
{
  if(digitalRead(btn) == LOW)
  {
      Serial.println(printStr);
      delay(300);
  }
}

