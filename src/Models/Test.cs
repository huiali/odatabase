using System;
using System.ComponentModel.DataAnnotations;

namespace ODataBase
{
    public class Test
    {
        [Key]
        public int Id { get; set; } //[int]
        public long? A { get; set; } //[bigint]
        public double? J { get; set; } //[float]
        public float? U { get; set; }  //[real]
        public bool? C { get; set; } //[bit]
        public Guid? Z4 { get; set; } //[uniqueidentifier]
        public short? W { get; set; } //[smallint]
        public DateTimeOffset? H { get; set; } //[datetimeoffset]
        public TimeSpan? Z1 { get; set; } //[time] (7)
        public byte? Z3 { get; set; } //[tinyint] NULL
        public string D { get; set; } // [char]
        public string P { get; set; } //[nchar]
        public string Q { get; set; } //[ntext]
        public string S { get; set; } //[nvarchar] (50)
        public string T { get; set; } //[nvarchar] (max)
        public string Z { get; set; } //[text]
        public string Z7 { get; set; } //[varchar]
        public string Z8 { get; set; } //[varchar](max)
        public string Z9 { get; set; } //[xml]
        public DateTime? E { get; set; } //[date] 
        public DateTime? F { get; set; } //[datetime] 
        public DateTime? G { get; set; }//[datetime2]
        public DateTime V { get; set; } //[smalldatetime]
        public decimal? I { get; set; } //[decimal](18, 0)
        public decimal? O { get; set; }//[money]
        public decimal? R { get; set; } //[numeric] (18, 0)
        public decimal? X { get; set; } //[smallmoney] 
        public byte[] B { get; set; } //[binary]
        public byte[] Z2 { get; set; } //[timestamp] NULL,
        public byte[] Z5 { get; set; } //[varbinary] (50) NULL,
        public byte[] Z6 { get; set; } // [varbinary]
        public byte[] N { get; set; } //[image]
    }
}
