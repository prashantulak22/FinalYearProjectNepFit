using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NepFit.Repository.Dto
{
    public class SendMailDto
    {
        public String Subject { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }



    }
}
