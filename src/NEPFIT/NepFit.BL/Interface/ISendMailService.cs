using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface ISendMailService
    {
        void SendEmail(SendMailDto input);
    }
}
