using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.settings
{
    /// <summary>
    /// configuration popur l'implemenetation des payment stripe
    /// </summary>
    public class StripeSettings
    {
        public string? SecretKey { get; set;}=string.Empty;
        public string? PublicKey { get; set;}=string.Empty;
    }
}
