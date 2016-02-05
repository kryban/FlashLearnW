using System;

namespace FlashLearnW.Interfaces
{
    public interface ICard
    {
        string ID { get; set; }
        string Question { get; set; }
        string Answer { get; set; }
        double EasinessFactor { get; set; }
        int NumberOfIterations { get; set; }
        DateTime ShowDate { get; set; }
    }
}
