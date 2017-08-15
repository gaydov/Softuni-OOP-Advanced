using SecurityDoor.Interfaces;

namespace SecurityDoor.Models
{
    public class PinCodeCheck : SecurityCheck
    {
        private readonly IPinCodeUI securityUI;

        public PinCodeCheck(IPinCodeUI securityUI)
        {
            this.securityUI = securityUI;
        }

        public override bool ValidateUser()
        {
            int pin = this.securityUI.RequestPinCode();

            if (this.IsValid(pin))
            {
                return true;
            }

            return false;
        }

        private bool IsValid(int pin)
        {
            return true;
        }
    }
}