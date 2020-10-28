using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive.DTO;

namespace CensusAnalyserLive
{
     public class CensusAnalyser
     { 
        public enum Country
        {
            INDIA,
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CsvAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
