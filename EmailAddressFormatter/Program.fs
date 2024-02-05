// For more information see https://aka.ms/fsharp-console-apps
module Program

open System 

type User = {
    FirstName : string
    LastName : string
    EmailAddress : string
} 
with 
    static member Zero = {
        User.FirstName = ""
        LastName = ""
        EmailAddress = ""
    }

let formatter (input : string) =
    input.Split(";")
    |> Array.map(fun i -> 
        //first position is last name
        //second position is first name
        //third position is email
        let x = i.TrimStart(' ').TrimEnd(' ').Split(" ")
        {
            FirstName = x.[1]
            LastName = x.[0].TrimEnd(',')
            EmailAddress = x.[2].TrimStart('<').TrimEnd('>')
        }
    )


[<EntryPoint>]
let main args =
    formatter args.[0] 
    |> Array.fold(fun state iter -> 
        match state with
        | "" -> iter.EmailAddress
        | _ -> state + ";" + iter.EmailAddress
    ) ""
    |> printf "%s"
    
    0