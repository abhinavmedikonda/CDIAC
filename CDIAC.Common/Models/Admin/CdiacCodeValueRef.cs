using System;

namespace CDIAC.Common.Models.Admin
{
    public class CdiacCodeValueRef
    {
        public long CdiacCodeValueId { get; set; }
        public string CdiacCode { get; set; }
        public string CdiacCodeValueCode { get; set; }
        public string CdiacCodeValueDesc { get; set; }
        public string ActiveInd { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime LastUpdateDatetime { get; set; }
        public string CreateUserId { get; set; }
        public string LastUpdateUserId { get; set; }
    }
}
