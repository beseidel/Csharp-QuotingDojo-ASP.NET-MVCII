using System;

namespace QuotingDojo.Models
{
    public class Quote
    {
  
       public string Name { get; set; }
  
       public string QuoteString { get; set; }
  
       public DateTime CreatedAt { get; set; }
       public int Id { get; set; }
    }
}