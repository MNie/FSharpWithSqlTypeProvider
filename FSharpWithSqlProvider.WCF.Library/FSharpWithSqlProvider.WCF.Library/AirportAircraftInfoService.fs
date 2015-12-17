namespace FSharpWithSqlProvider.WCF.Library

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq
open System.ServiceModel
open System.ServiceModel.Web
open System.Runtime.Serialization
open System.Diagnostics

[<DataContract>]
[<Serializable>]
type AircraftInfo(planeNumber, operator, area) = 
    [<DataMember>] member val PlaneNumber = planeNumber with get,set
    [<DataMember>] member val Operator = operator with get,set
    [<DataMember>] member val Area = area with get,set

[<ServiceContract()>]
type IAirportAircraftInfoService =
    [<OperationContract>]
    abstract GetAll : unit -> AircraftInfo array

type dbSchema = SqlDataConnection<"Data Source=localhost;Initial Catalog=Airport;Integrated Security=False; User Id=AirportUser; Password=aaAA11!!;">

[<ServiceBehaviorAttribute(ConcurrencyMode = ConcurrencyMode.Multiple)>]
type AirportAircraftInfoService() =
    interface IAirportAircraftInfoService with
        member this.GetAll() =
            let db = dbSchema.GetDataContext()
            query {
                for row in db.AircraftSchedule do
                select row
            } 
            |> Seq.map (fun row -> AircraftInfo(row.PlaneNumber, row.Operator, row.Area))
            |> Seq.toArray

