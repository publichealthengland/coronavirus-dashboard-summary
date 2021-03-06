module coronavirus_dashboard_summary.Templates.RateDetail

open System
open coronavirus_dashboard_summary.Models
open Giraffe.ViewEngine

[<Literal>]
let private IgnoredRate    = "newCasesBySpecimenDateRollingRate"

[<Literal>]
let private EnglandInitial = "E"


let inline Render (metadata: MetaData.ContentMetadata) (getter: string -> string -> string): XmlNode =
    match String.IsNullOrEmpty metadata.rate with
    | true -> String.Empty
              |> rawText
    | _    ->     
        match (getter metadata.metric "area_code").StartsWith EnglandInitial && metadata.rate.Equals IgnoredRate with
        | true -> String.Empty
                  |> rawText
        | _    -> 
            details [
                _class "govuk-details govuk-!-margin-top-1 govuk-!-margin-bottom-1"
                _data "module" "govuk-details"
            ] [
                summary [ _class "govuk-details__summary" ] [
                    span [ _class "govuk-details__summary-text body-small" ] [
                        encodedText "Rate per 100,000 people:"
                        rawText "&nbsp;"
                        strong [] [
                            getter metadata.rate "formattedValue"
                            |> encodedText
                        ]
                    ]
                ]
                div [ _class "govuk-details__text" ] [
                    span [ _class "body-small" ] [
                        encodedText "7-day rolling rate"
                        rawText "&nbsp;"
                        encodedText metadata.description
                        " "
                        + getter metadata.rate "formattedDate"
                        |> encodedText
                    ]
                ]
            ] 
