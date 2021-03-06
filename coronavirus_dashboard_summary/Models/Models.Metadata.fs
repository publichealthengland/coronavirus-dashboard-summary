module coronavirus_dashboard_summary.Models.MetaData

[<Struct>]
type ContentMetadata =
    {
        metric:              string
        rate:                string
        sum:                 string
        caption:             string
        heading:             string
        postcodeDestination: string
        rateOffset:          bool
        postCodeOnly:        bool
        landingOnly:         bool
        description:         string
    }

let CardMetadata: ContentMetadata[] = [|
    {
        metric              = "newCasesBySpecimenDate"
        rate                = "newCasesBySpecimenDateRollingRate"
        sum                 = "newCasesBySpecimenDateRollingSum"
        caption             = null
        heading             = null
        postcodeDestination = null
        rateOffset          = true
        postCodeOnly        = true
        landingOnly         = false
        description         = null
    }
    {
        metric              = "newPeopleVaccinatedFirstDoseByPublishDateRollingSum"
        rate                = null
        sum                 = "newPeopleVaccinatedFirstDoseByPublishDateRollingSum"
        caption             = "Vaccinations"
        heading             = "People vaccinated"
        postcodeDestination = "ltla"
        rateOffset          = true
        postCodeOnly        = false
        landingOnly         = false
        description         = null
    }
    {
        metric              = "newCasesBySpecimenDate"
        rate                = "newCasesBySpecimenDateRollingRate"
        sum                 = "newCasesBySpecimenDateRollingSum"
        caption             = "Cases"
        heading             = "People tested positive"
        postcodeDestination = "ltla"
        rateOffset          = true
        postCodeOnly        = false
        landingOnly         = true
        description         = "by date of specimen as of"
    }
    {
        metric              = "newDeaths28DaysByDeathDate"
        rate                = "newDeaths28DaysByDeathDateRollingRate"
        sum                 = "newDeaths28DaysByDeathDateRollingSum"
        caption             = "Deaths"
        heading             = "Deaths within 28 days of positive test"
        postcodeDestination = "ltla"
        rateOffset          = true
        postCodeOnly        = false
        landingOnly         = false
        description         = "by date of death as of"
    }
    {
        metric              = "newAdmissions"
        rate                = null
        sum                 = "newAdmissionsRollingSum"
        caption             = "Healthcare"
        heading             = "Patients admitted"
        postcodeDestination = "nhsTrust"
        rateOffset          = false
        postCodeOnly        = false
        landingOnly         = false
        description         = null
    }
    {
        metric              = "newVirusTestsByPublishDate"
        rate                = null
        sum                 = "newVirusTestsByPublishDateRollingSum"
        caption             = "Testing"
        heading             = "Virus tests conducted"
        postcodeDestination = "nation"
        rateOffset          = false
        postCodeOnly        = false
        landingOnly         = false
        description         = null
    }
    {
        metric              = "transmissionRateMin"
        rate                = null
        sum                 = null
        caption             = "Transmission"
        heading             = "R value"
        postcodeDestination = null
        rateOffset          = false
        postCodeOnly        = true
        landingOnly         = false
        description         = null
    }
|]
