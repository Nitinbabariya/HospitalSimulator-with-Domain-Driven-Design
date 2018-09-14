using System;

namespace Simulator.Query.Consultation
{
    public static class ConsultationQueriesFactory{
        public static GetConsultationQuery GetAllScheduledConsultationQuery => new GetConsultationQuery(x => x.ConsultationDate>= DateTime.UtcNow.Date);
    }
}