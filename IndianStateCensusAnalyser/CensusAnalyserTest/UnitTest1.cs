using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest;

public class Tests
{

    //CensusAnalyser.CensusAnalyser censusAnalyser;

    static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
    static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
    static string indianStateCensusFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/IndiaStateCensusData.csv";
    static string wrongHeaderIndianCensusFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/WrongIndiaStateCensusData.csv";
    static string delimiterIndianCensusFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/DelimiterIndiaStateCensusData.csv";
    static string wrongIndianStateCensusFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/WrongIndiaStateCensusData.csv";
    static string wrongIndianStateCensusFileType = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/IndiaStateCensusData.csv";
    static string indianStateCodeFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/IndiaStateCode.csv";
    static string wrongIndianStateCodeFileType = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/IndiaStateCode.csv";
    static string delimiterIndianStateCodeFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/DelimiterIndiaStateCode.csv";
    static string wrongHeaderStateCodeFilePath = "/Users/piyushshaw/Projects/IndianStateCensusAnalyser/CensusAnalyserTest/CsvFiles/WrongIndiaStateCode.csv";
    //US Census FilePath
    //static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
    //static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
    //static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
    //static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
    //static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
    //static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

    CensusAnalyser censusAnalyser;
    Dictionary<string, CensusDTO> totalRecord;
    Dictionary<string, CensusDTO> stateRecord;

    [SetUp]
    public void Setup()
    {
        censusAnalyser = new CensusAnalyser();
        totalRecord = new Dictionary<string, CensusDTO>();
        stateRecord = new Dictionary<string, CensusDTO>();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
    {
        totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
        stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
        Assert.AreEqual(29, totalRecord.Count);
        Assert.AreEqual(37, stateRecord.Count);
    }

    [Test]
    public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
    {
        var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
        var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
        Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
    }

}



