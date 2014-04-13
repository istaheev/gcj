module Problem_C_1C

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

type BoardValue = Black | White | Cutted

let bit n index = 
    if (n >>> (3-index)) &&& 1 = 0 then Black else White


let cutBoard (board : BoardValue [,]) col row size =
    for y in [row..row+size-1] do
        for x in [col..col+size-1] do
            board.[y,x] <- Cutted


let rec validBoard board col row coffs roffs size = 
    if coffs >= size then validBoard board col row 0 (roffs+1) size
    else if roffs >= size 
         then
            //printfn "Board of size %d found at %d,%d" size col row
            cutBoard board col row size
            true
         else
            let cell = board.[row+roffs, col+coffs]
            if cell = Cutted then false
            else
                let idx = (coffs + roffs) % 2
                if (idx = 0 && board.[row,col] = cell) || (idx = 1 && board.[row,col] <> cell)
                    then validBoard board col row (coffs+1) roffs size
                    else false
    

let rec searchBoard board width height col row size =
    if col > width-size then searchBoard board width height 0 (row+1) size
    else if row > height-size then false
         else if validBoard board col row 0 0 size then true
              else searchBoard board width height (col+1) row size
            

let rec searchBoardsWithSize board width height size =
    //printfn "searchBoardWithSize %d" size
    if searchBoard board width height 0 0 size 
        then 1 + searchBoardsWithSize board width height size
        else 0
        
       
let problemC testIndex =
    let sizes = readIntegers ()
    let height, width = sizes.[0], sizes.[1]
    let board = Array2D.create height width Cutted
    for row in [0..height-1] do
        let nar = (readString ()).ToCharArray () |> 
                  Array.map (fun ch -> if ch >= '0' && ch <= '9' then int ch - int '0' else int ch - int 'A' + 10)
        for col in [0..width-1] do
            board.[row,col] <- bit nar.[col/4] (col%4)
    
    (*        
    for row in [0..height-1] do
        for col in [0..width-1] do
            printf "%d" (if board.[row,col] = Black then 0 else 1)
        printfn ""
    *)
    
    let foundedBoards = new Dictionary<int,int> ()
    
    let maxSize = min width height    
    
    for size in List.rev [1..maxSize] do
        match searchBoardsWithSize board width height size with
            | 0 -> ()
            | n -> foundedBoards.Add (size, n)
         
    printfn "Case #%d: %d" testIndex foundedBoards.Count

    let sizes = List.ofSeq foundedBoards.Keys
    
    for key in List.sort sizes |> List.rev do
        printfn "%d %d" key foundedBoards.[key]
   
let main () =
    for testIndex in [1..readInteger ()] do
        problemC testIndex

do main ()
