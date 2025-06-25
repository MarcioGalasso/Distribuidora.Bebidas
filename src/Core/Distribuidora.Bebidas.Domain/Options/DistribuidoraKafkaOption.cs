using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora.Bebidas.Domain.Options
{
    public class DistribuidoraKafkaOption
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string GroupName { get; set; }
        public string TopicConsumerName { get; set; }
        public string TopicConsumerRetryDelivery { get; set; }
        public string TopicConsumerPreparationOrder { get; set; }
    }
}
