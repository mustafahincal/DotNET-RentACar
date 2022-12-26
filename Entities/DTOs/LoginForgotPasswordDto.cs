using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
      public class LoginForgotPasswordDto : IDto
      {
            public string Email { get; set; }
            public int ResetCode { get; set; }
            public string NewPass { get; set; }

      }
}
