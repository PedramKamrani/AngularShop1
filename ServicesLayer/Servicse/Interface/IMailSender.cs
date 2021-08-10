namespace ServicesLayer.Servicse.Interface
{
    public interface IMailSender
    {
        void Send(string to, string subject, string body);
    }
}
