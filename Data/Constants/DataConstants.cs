using System;

namespace covid19.Data
{
    public static class DataConstants
    {

        public static class RESTUrl
        {
            public const string GET_ALL_TABLES = "https://www150.statcan.gc.ca/t1/wds/rest/getAllCubesList";
            public const string GET_CHANGED_TABLES = "https://www150.statcan.gc.ca/t1/wds/rest/getChangedCubeList";
            public const string GET_TABLE_METADATA = "https://www150.statcan.gc.ca/t1/wds/rest/getCubeMetadata";
            public const string POST_DATA_VECTORS_N = "https://www150.statcan.gc.ca/t1/wds/rest/getDataFromVectorsAndLatestNPeriods";
            public const string POST_DATA_VECTOR = "https://www150.statcan.gc.ca/t1/wds/rest/getSeriesInfoFromVector";
            public const string POST_CHANGED_DATA_VECTOR = "https://www150.statcan.gc.ca/t1/wds/rest/getChangedSeriesDataFromVector";
        }

        public static class ProductId
        {
            public const string GDP = "36100434";
            public const string DEBT = "10100002";
            public const string RETAIL = "20100008";
            public const string MANUFACTURING = "16100047";
            public const string EMPLOYMENT = "14100287";
            public const string CPI = "18100004";
        }

        public static class VectorId
        {
            public const string GDP_ALL_INDUSTRIES = "65201210";
            public const string CPI_ALL_ITEMS = "41690973";
            public const string MANUFACTURING_ALL = "800025";
            public const string RETAIL_ALL = "52367097";
            public const string NET_DEBT = "86822803";
        }
        
    }
}