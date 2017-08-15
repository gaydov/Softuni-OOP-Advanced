using SecurityDoor.Models;

namespace SecurityDoor
{
    public class Launcher
    {
        public static void Main()
        {
            ScannerUI scannerUi = new ScannerUI();
            KeyCardCheck keyCardCheck = new KeyCardCheck(scannerUi);
            PinCodeCheck pinCodeCheck = new PinCodeCheck(scannerUi);
            SecurityManager manager = new SecurityManager(keyCardCheck, pinCodeCheck);
            manager.Check();
        }
    }
}
