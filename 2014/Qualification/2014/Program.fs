open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let readIntegers () = 
    readString () |> parseIntegers

let readInteger () = (readIntegers ()).[0]

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
