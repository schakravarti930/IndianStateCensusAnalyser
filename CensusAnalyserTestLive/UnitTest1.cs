using NUnit.Framework;
using System.Collections.Generic;
using CensusAnalyserLive.DTO;
using CensusAnalyserLive;
using static CensusAnalyserLive.CensusAnalyser;
namespace CensusAnalyserTestLive
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/IndiaStateCode.csv";
        static string wrongHeaderIndianStateCensusFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/WrongIndiaStateCensusData.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/WrongIndiaStateCode.csv";
        static string wrongDelimiterIndianStateCensusFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"/home/swapnil/Desktop/C# Practice/IndianStateCensusAnalyser/CensusAnalyserTestLive/CSVFiles/DelimiterIndiaStateCode.csv";
        CensusAnalyserLive.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyserLive.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenFileWithWrongHeaders_ShouldReturn_IncorrectDataHeaderException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA,wrongHeaderIndianStateCensusFilePath,indianStateCensusHeaders);
            }
            catch(CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data",e.Message);
            }
        }
        [Test]
        public void GivenStateCodeWithWrongHeader_ShouldReturn_CustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA,wrongHeaderIndianStateCodeFilePath,indianStateCensusHeaders);
            }
            catch(CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data",e.Message);
            }
        }
        [Test]
        public void GivenCensusDataWithWrongDelimiter_ShouldReturn_WrongDelimiterException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA,wrongDelimiterIndianStateCensusFilePath,indianStateCensusHeaders);
            }
            catch(CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter",e.Message);
            }
        }
        [Test]
        public void GivenStateCodeWithWrongDelimiter_ShouldReturn_WrongDelimiterException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA,wrongDelimiterIndianStateCodeFilePath,indianStateCodeHeaders);
            }
            catch(CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter",e.Message);
            }
        }
    }
}