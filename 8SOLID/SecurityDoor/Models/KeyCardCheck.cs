using SecurityDoor.Interfaces;

namespace SecurityDoor.Models
{
    public class KeyCardCheck : SecurityCheck
    {
        private readonly IKeyCardUI securityUI;

        public KeyCardCheck(IKeyCardUI securityUI)
        {
            this.securityUI = securityUI;
        }

        public override bool ValidateUser()
        {
            string code = this.securityUI.RequestKeyCard();

            if (this.IsValid(code))
            {
                return true;
            }

            return false;
        }

        private bool IsValid(string code)
        {
            return true;
        }
    }
}