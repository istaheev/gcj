module Problem_A_1B

open System
open System.Collections.Generic

(*** helpers **)

let readString () = Console.ReadLine()

let parseIntegers (s : string) =
    s.Split(' ') |> Array.map int
    
let readIntegers () = 
    readString () |> parseIntegers

let readInteger () = (readIntegers ()).[0]

(* problem code *)

let directoryMap = new Dictionary<string,bool> ()


let checkBound n bound boundValue = if n = bound then boundValue else n

let addPathPart pathPart = 
    if directoryMap.ContainsKey (pathPart) then 0
    else directoryMap.Add (pathPart, true); 1


let rec processPath (path : string) startIndex =
    if startIndex >= path.Length then 0
    else                         
        let pos = checkBound (path.IndexOf('/', startIndex)) -1 path.Length
        let partPath = path.Substring (0, pos)
        let c = addPathPart partPath
        //printfn "checking %s: %d" partPath c
        c + processPath path (pos+1)

    
let rec fillDirectories = function
        [] -> 0
        | path::tail -> processPath path 1 + fillDirectories tail


let problemA () =
    directoryMap.Clear ()
    let counts = readIntegers ()
    List.init counts.[0] (fun _ -> readString ()) |> fillDirectories |> ignore
    List.init counts.[1] (fun _ -> readString ()) |> fillDirectories
 
    
let main () =
    for testIndex in [1..readInteger ()] do
        let creationsCount = problemA ()
        printfn "Case #%d: %d" testIndex creationsCount


//do main ()
