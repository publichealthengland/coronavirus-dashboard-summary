module coronavirus_dashboard_summary.Models.AnnouncementModel

open System
open Npgsql.FSharp
open coronavirus_dashboard_summary.Models.DB
open FSharp.Json

[<Literal>]
let private Query = "
WITH latest_release AS (
    SELECT MAX(rr.timestamp)::DATE
    FROM covid19.release_reference AS rr
    WHERE rr.released IS TRUE
)
SELECT COALESCE(date, launch::DATE) AS date,
       body
FROM covid19.announcement AS an
WHERE
    (
         ( an.deploy_with_release IS TRUE  AND an.launch::DATE <= (SELECT * FROM latest_release) )
      OR ( an.deploy_with_release IS FALSE AND an.launch <= NOW() )
    )
  AND (
         ( an.remove_with_release IS TRUE  AND an.expire::DATE > (SELECT * FROM latest_release) )
      OR ( an.remove_with_release IS FALSE AND an.expire > NOW() )
    )
ORDER BY an.launch DESC, an.expire DESC;"

type Announcements(redis, date, telemetry) =
    inherit DataBase<AnnouncementPayload>(redis, date, telemetry)
    override this.keyPrefix     = "announcement"
    override this.keySuffix     = "UK"
    override this.cacheDuration =
        {
            hours   = 0
            minutes = Random().Next(12, 18)
            seconds = Random().Next(0, 60)
        }
        
    override this.queryParams () =
        [
            "@date", Sql.timestamp this.date.timestamp
        ]
       
    override this.query = Query
      
    static member inline Data redis date telemetry: Async<AnnouncementPayload list> =
        let fetcher = Announcements(redis, date, telemetry)
        
        async {
            let! result = redis.GetAsync fetcher.key (fetcher :> IDatabase<AnnouncementPayload>).fetchFromDB
            
            return match result with
                   | Some res -> Json.deserialize<AnnouncementPayload list>(res)
                   | _        -> []
        }
