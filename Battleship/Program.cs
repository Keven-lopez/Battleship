using System;

string[,] board = new string [ 10, 10 ];
string[,] ai_board = new string[ 10, 10 ];
string[,] temp_board = new string[ 10, 10 ];
string[,] ai_temp_board = new string[10, 10];
string vert_start = @" /\", vert_mid = " ||", vert_end = @" \/";
string hori_start = "  <", hori_mid = "  =", hori_end = "  >";
string[] boat_parts = { vert_start, vert_mid, vert_end, hori_start, hori_mid, hori_end };
string confirm;
int row=0, col=0, orient, choice, valid_place = 0, player_hit=0, ai_hit=0;
bool valid = false, valid_pos = false, hit = false, hit_ai=false;
bool out_of_bounds = false, invalids = false, already_placed = false, turn1_pass=false; //errors
bool des = false, sub = false, cruc = false, acor = false, port = false; //checklist

void clear_board() {
    for (int i = 0; i < 10; i++) //filling board with 0's
    {
        for (int j = 0; j < 10; j++)
        {
            board[i, j] = "  0";
            temp_board[i, j] = "  0";
            ai_board[i, j] = "  0";
            ai_temp_board[i, j] = "  0";
        }
    }
    des = false;
    sub = false;
    cruc = false;
    acor = false;
    port = false;
}

void boat_placement()
{
    Console.WriteLine("Fila: ");
    row = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Columna: ");
    col = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Vertical o Horizontal?(1=vert 2=hori)");
    orient = Convert.ToInt32(Console.ReadLine());
}

void placement_validation()
{
    valid_place = 0;
    switch (choice) 
    {
        case 1: //destroyer
            if (orient == 1)
            {
                for (int i = 0; i < 2; ++i)
                {
                    if (board[row - i, col] != "  0") // every invalid placement increases counter by 1
                    {
                        valid_place++;
                    }
                }
            } 
            else if (orient==2)
            {
                for (int i = 0; i < 2; ++i)
                {
                    if (board[row, col - i] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
        break;
        case 2: //submarine
            if (orient == 1)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (board[row - i, col] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            else if (orient == 2)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (board[row, col - i] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            break;
        case 3: //crucero
            if (orient == 1)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (board[row - i, col] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            else if (orient == 2)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if (board[row, col - i] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            break;
        case 4: //acorzado
            if (orient == 1)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (board[row - i, col] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            else if (orient == 2)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (board[row, col - i] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            break;
        case 5: //portaaviones
            if (orient == 1)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (board[row - i, col] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            else if (orient == 2)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (board[row, col - i] != "  0")
                    {
                        valid_place++;
                    }
                }
            }
            break;
    }
    if (valid_place == 0) // position is valid if counter = 0
    {
        valid_pos = true;
    }
    else
    {
        valid_pos = false;
    }
}

void checklist()
{
    if (des == true)
    {
        Console.WriteLine("Destructor: Colocado");
    }
    else if (des == false) 
    {
        Console.WriteLine("Destructor: No colocado");
    }

    if (sub == true)
    {
        Console.WriteLine("Submarino: Colocado");
    }
    else if (sub == false)
    {
        Console.WriteLine("Submarino: No colocado");
    }

    if (cruc == true)
    {
        Console.WriteLine("Crucero: Colocado");
    }
    else if (cruc == false)
    {
        Console.WriteLine("Crucero: No colocado");
    }

    if (acor == true)
    {
        Console.WriteLine("Acorzado: Colocado");
    }
    else if (acor == false)
    {
        Console.WriteLine("Acorzado: No colocado");
    }

    if (port == true)
    {
        Console.WriteLine("Portaaviones: Colocado");
    }
    else if (port == false)
    {
        Console.WriteLine("Portaaviones: No colocado");
    }

}

void errors()
{
    if (out_of_bounds == true)
    {
        Console.WriteLine("Posicion fuera del rango");
        out_of_bounds = false;
    }
    else if (invalids == true)
    {
        Console.WriteLine("Posicion Invalida");
        invalids = false;
    }
    else if (already_placed == true)
    {
        Console.WriteLine("Ya colocado. Si deseas cambiar la posicion, borra todo.");
        already_placed = false;
    }
}

void destroyer()
{
    switch (orient)
    {
        case 1:
            valid = false;
            for (int i = 0; i < 2; i++)
            {
                row += 1;
            }
            if (row >= 10)
            {
               out_of_bounds = true;
               break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                row -= 2;
                board[row, col] = vert_start;
                board[row + 1, col] = vert_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        des = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row + 1, col] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {   
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
        break;
        case 2:
                valid = false;
                for (int i=0; i < 2; i++)
                {
                    col += 1;
                }
                if (col >= 10)
                {
                    out_of_bounds = true;
                break;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            temp_board[i, j] = board[i, j];
                        }
                    }
                    placement_validation();
                    col -= 1;
                    board[row, col] = hori_start;
                    board[row, col + 1] = hori_end;
                }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        des = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row, col + 1] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if(valid_pos== false)
            {
                invalids= true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
    }
}

void submarino()
{
    switch (orient)
    {
        case 1:
            valid = false;
            for (int i = 0; i < 3; i++)
            {
                row += 1;
            }
            if (row >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                row -= 3;
                board[row, col] = vert_start;
                board[row + 1, col] = vert_mid;
                board[row + 2, col] = vert_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        sub = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row + 1, col] = "  0";
                        board[row + 2, col] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;    
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
        case 2:
            valid = false;
            for (int i = 0; i < 3; i++)
            {
                col += 1;
            }
            if (col >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                col -= 2;
                board[row, col] = hori_start;
                board[row, col + 1] = hori_mid;
                board[row, col + 2] = hori_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        sub = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row, col + 1] = "  0";
                        board[row, col + 2] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
    }
}

void crucero()
{
       switch (orient)
        {
            case 1:
                valid = false;
                for (int i = 0; i < 3; i++)
                {
                    row += 1;
                }
                if (row >= 10)
                {
                    out_of_bounds = true;
                    break;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            temp_board[i, j] = board[i, j];
                        }
                    }
                    placement_validation();
                    row -= 3;
                    board[row, col] = vert_start;
                    board[row + 1, col] = vert_mid;
                    board[row + 2, col] = vert_end;
                }
                if (valid_pos == true)
                {
                    mostrar_tabla();
                    Console.WriteLine("Confirmar? Y/N");
                    confirm = Console.ReadLine();
                    confirm.ToLower();
                    switch (confirm)
                    {
                        case "y":
                            valid = true;
                            cruc = true;
                            break;
                        case "n":
                            board[row, col] = "  0";
                            board[row + 1, col] = "  0";
                            board[row + 2, col] = "  0";
                            Console.Clear();
                            break;
                    }
                }
                else if (valid_pos == false)
                {
                    invalids = true;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            board[i, j] = temp_board[i, j];
                        }
                    }
                }
                break;
            case 2:
                valid = false;
                for (int i = 0; i < 3; i++)
                {
                    col += 1;
                }
                if (col >= 10)
                {
                    out_of_bounds = true;
                    break;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            temp_board[i, j] = board[i, j];
                        }
                    }
                    placement_validation();
                    col -= 3;
                    board[row, col] = hori_start;
                    board[row, col + 1] = hori_mid;
                    board[row, col + 2] = hori_end;
                }
                if (valid_pos == true)
                {
                    mostrar_tabla();
                    Console.WriteLine("Confirmar? Y/N");
                    confirm = Console.ReadLine();
                    confirm.ToLower();
                    switch (confirm)
                    {
                        case "y":
                            valid = true;
                            cruc = true;
                            break;
                        case "n":
                            board[row, col] = "  0";
                            board[row, col + 1] = "  0";
                            board[row, col + 2] = "  0";
                            Console.Clear();
                            break;
                    }
                }
                else if (valid_pos == false)
                {
                    invalids = true;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            board[i, j] = temp_board[i, j];
                        }
                    }
                }
                break;
        }
    }

void acorzado()
{
    switch (orient)
    {
        case 1:
            valid = false;
            for (int i = 0; i < 4; i++)
            {
                row += 1;
            }
            if (row >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                row -= 4;
                board[row, col] = vert_start;
                board[row + 1, col] = vert_mid;
                board[row + 2, col] = vert_mid;
                board[row + 3, col] = vert_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        acor = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row + 1, col] = "  0";
                        board[row + 2, col] = "  0";
                        board[row + 3, col] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
        case 2:
            valid = false;
            for (int i = 0; i < 3; i++)
            {
                col += 1;
                Console.WriteLine(col);
            }
            if (col >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                col -= 3;
                board[row, col] = hori_start;
                board[row, col + 1] = hori_mid;
                board[row, col + 2] = hori_mid;
                board[row, col + 3] = hori_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        acor = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row, col + 1] = "  0";
                        board[row, col + 2] = "  0";
                        board[row, col + 3] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
    }
}

void portaaviones()
{
    switch (orient)
    {
        case 1:
            valid = false;
            for (int i = 0; i < 4; i++)
            {
                row += 1;
            }
            if (row >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                row -= 4;
                board[row, col] = vert_start;
                board[row + 1, col] = vert_mid;
                board[row + 2, col] = vert_mid;
                board[row + 3, col] = vert_mid;
                board[row + 4, col] = vert_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        port = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row + 1, col] = "  0";
                        board[row + 2, col] = "  0";
                        board[row + 3, col] = "  0";
                        board[row + 4, col] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
        case 2:
            valid = false;
            for (int i = 0; i < 4; i++)
            {
                col += 1;
            }
            if (col >= 10)
            {
                out_of_bounds = true;
                break;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp_board[i, j] = board[i, j];
                    }
                }
                placement_validation();
                col -= 4;
                board[row, col] = hori_start;
                board[row, col + 1] = hori_mid;
                board[row, col + 2] = hori_mid;
                board[row, col + 3] = hori_mid;
                board[row, col + 4] = hori_end;
            }
            if (valid_pos == true)
            {
                mostrar_tabla();
                Console.WriteLine("Confirmar? Y/N");
                confirm = Console.ReadLine();
                confirm.ToLower();
                switch (confirm)
                {
                    case "y":
                        valid = true;
                        port = true;
                        break;
                    case "n":
                        board[row, col] = "  0";
                        board[row, col + 1] = "  0";
                        board[row, col + 2] = "  0";
                        board[row, col + 3] = "  0";
                        board[row, col + 4] = "  0";
                        Console.Clear();
                        break;
                }
            }
            else if (valid_pos == false)
            {
                invalids = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        board[i, j] = temp_board[i, j];
                    }
                }
            }
            break;
    }
}

void mostrar_tabla()
{
    Console.WriteLine("    0  1  2  3  4  5  6  7  8  9");
    Console.WriteLine("________________________________");
    for (int i = 0; i < 10; i++)
    {
        Console.Write($"{i}|");
        for (int j = 0; j < 10; j++)
        {
            Console.Write($"{board[i, j]}");
        }
        Console.WriteLine("");
    }
}

void player_place()
{
    do
    {
        Console.Clear();
        mostrar_tabla();
        errors();
        Console.WriteLine("Select boat:\n1. Destructor (Dos Espacios)\n2. Submarino(Tres Espacios)\n3. Crucero(Tres Espacios)\n4. Acorazado(Cuatro Espacios)\n5. Portaaviones(Cinco Espacios)\n6. Borrar todo\n7. Listo\n");
        checklist();
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                if (des == true)
                {
                    already_placed = true;
                    break;
                }
                do
                {
                    Console.Clear();
                    mostrar_tabla();
                    errors();
                    boat_placement();
                    destroyer();
                } while (valid == false);
                break;
            case 2:
                if (sub == true)
                {
                    already_placed = true;
                    break;
                }
                do
                {
                    Console.Clear();
                    mostrar_tabla();
                    errors();
                    boat_placement();
                    submarino();
                } while (valid == false);
                break;
            case 3:
                if (cruc == true)
                {
                    already_placed = true;
                    break;
                }
                do
                {
                    Console.Clear();
                    mostrar_tabla();
                    errors();
                    boat_placement();
                    crucero();
                } while (valid == false);
                break;
            case 4:
                if (acor == true)
                {
                    already_placed = true;
                    break;
                }
                do
                {
                    Console.Clear();
                    mostrar_tabla();
                    errors();
                    boat_placement();
                    acorzado();
                } while (valid == false);
                break;
            case 5:
                if (port == true)
                {
                    already_placed = true;
                    break;
                }
                do
                {
                    Console.Clear();
                    mostrar_tabla();
                    errors();
                    boat_placement();
                    portaaviones();
                } while (valid == false);
                break;
            case 6:
                clear_board();
                Console.Clear();
                break;
            case 7:
                break;
            default:
                Console.WriteLine("Opcion Invalida");
                break;
        }
    } while (choice != 7);
}

void ai_destroyer()
{
    Random random = new Random();
    orient = random.Next(1, 11);
    if (orient % 2 == 0)
    {
        do
        {
            row = random.Next(0, 10);
        } while (row > 8);
        col = random.Next(0, 9);
        ai_board[row, col] = vert_start;
        ai_board[row + 1, col] = vert_end;
    }
    else if (orient % 2 != 0)
    {
        do
        {
            col = random.Next(0, 10);
        } while (col > 8);
        row = random.Next(0, 9);
        ai_board[row, col] = hori_start;
        ai_board[row, col + 1] = hori_end;
    }
}

void ai_submarine()
{
    Random random = new Random();
    orient = random.Next(1, 11);
    if (orient % 2 == 0)
    {
        do 
        {
            valid_place = 0; 
            do
            {
                row = random.Next(0, 10);
            } while (row > 7);
            col = random.Next(0, 9);
            for (int i = 0; i < 3; i++)
            {
                if (ai_board[row + i, col] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = vert_start;
        ai_board[row + 1, col] = vert_mid;
        ai_board[row + 2, col] = vert_end;
    }
    else if (orient % 2 != 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                col = random.Next(0, 10);
            } while (col > 7);
            row = random.Next(0, 9);
            for (int i = 0; i < 3; i++)
            {
                if (ai_board[row, col + i] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = hori_start;
        ai_board[row, col + 1] = hori_mid;
        ai_board[row, col + 2] = hori_end;
    }
}

void ai_cruc()
{
    Random random = new Random();
    orient = random.Next(1, 11);
    if (orient % 2 == 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                row = random.Next(0, 10);
            } while (row > 7);
            col = random.Next(0, 9);
            for (int i = 0; i < 3; i++)
            {
                if (ai_board[row + i, col] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = vert_start;
        ai_board[row + 1, col] = vert_mid;
        ai_board[row + 2, col] = vert_end;
    }
    else if (orient % 2 != 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                col = random.Next(0, 10);
            } while (col > 7);
            row = random.Next(0, 9);
            for (int i = 0; i < 3; i++)
            {
                if (ai_board[row, col + i] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = hori_start;
        ai_board[row, col + 1] = hori_mid;
        ai_board[row, col + 2] = hori_end;
    }
}

void ai_acorzado(){
    Random random = new Random();
    orient = random.Next(1, 11);
    if (orient % 2 == 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                row = random.Next(0, 10);
            } while (row > 6);
            col = random.Next(0, 9);
            for (int i = 0; i < 4; i++)
            {
                if (ai_board[row + i, col] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = vert_start;
        ai_board[row + 1, col] = vert_mid;
        ai_board[row + 2, col] = vert_mid;
        ai_board[row + 3, col] = vert_end;
    }
    else if (orient % 2 != 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                col = random.Next(0, 10);
            } while (col > 6);
            row = random.Next(0, 9);
            for (int i = 0; i < 4; i++)
            {
                if (ai_board[row, col + i] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = hori_start;
        ai_board[row, col + 1] = hori_mid;
        ai_board[row, col + 2] = hori_mid;
        ai_board[row, col + 3] = hori_end;
    }
}

void ai_portaaviones()
{
    Random random = new Random();
    orient = random.Next(1, 11);
    if (orient % 2 == 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                row = random.Next(0, 10);
            } while (row > 5);
            col = random.Next(0, 9);
            for (int i = 0; i < 5; i++)
            {
                if (ai_board[row + i, col] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = vert_start;
        ai_board[row + 1, col] = vert_mid;
        ai_board[row + 2, col] = vert_mid;
        ai_board[row + 3, col] = vert_mid;
        ai_board[row + 4, col] = vert_end;
    }
    else if (orient % 2 != 0)
    {
        do
        {
            valid_place = 0;
            do
            {
                col = random.Next(0, 10);
            } while (col > 5);
            row = random.Next(0, 9);
            for (int i = 0; i < 5; i++)
            {
                if (ai_board[row, col + i] != "  0")
                {
                    valid_place++;
                }
            }
        } while (valid_place != 0);
        ai_board[row, col] = hori_start;
        ai_board[row, col + 1] = hori_mid;
        ai_board[row, col + 2] = hori_mid;
        ai_board[row, col + 3] = hori_mid;
        ai_board[row, col + 4] = hori_end;
    }
}

void ai_place()
{
    ai_destroyer();
    ai_submarine();
    ai_cruc();
    ai_acorzado();
    ai_portaaviones();
}

void player_turn()
{
    Console.WriteLine("Fila: ");
    row = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Columna: ");
    col = Convert.ToInt32(Console.ReadLine());

    hit = false;

    foreach (string s in boat_parts)
    {
        if (s == ai_board[row, col])
        {
            temp_board[row, col] = "  X";
            ai_board[row, col] = "  0";
            player_hit++;
            hit = true;
            break;
        }
    }

    if (!hit)
    {
        temp_board[row, col] = "  M";
    }
}

void ai_turn()
{
    Random random = new Random();
    row = random.Next(0, 10);
    col = random.Next(0, 10);


    foreach (string s in boat_parts)
    {
        if (s == board[row, col])
        {
            ai_temp_board[row, col] = "  X";
            board[row, col] = "  0";
            ai_hit++;
            hit_ai = true;
            break;
        }
    }

    if (!hit)
    {
        ai_temp_board[row, col] = "  M";
    }
}

void hit_check()
{
    if (turn1_pass == true)
    {
        if (hit)
        {
            Console.WriteLine("Atacaste un barco");
        }
        else if (!hit)
        {
            Console.WriteLine("Fallaste");
        }
        if (hit_ai)
        {
            Console.WriteLine("El AI ataco un barco");
        }
        else if (!hit_ai)
        {
            Console.WriteLine("El AI fallo");
        }
    }
}

clear_board();
ai_place();

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        temp_board[i, j] = "  0";
        ai_temp_board[i, j] = "  0";
    }
}

do
{
    Console.Clear();
    Console.WriteLine($"Faltan {18 - player_hit} X's para ganar");
    Console.WriteLine($"Al AI le falta {18 - ai_hit} X's para ganar");
    hit_check();
    Console.WriteLine("Tu turno:                            EL AI:");
    Console.WriteLine("    0  1  2  3  4  5  6  7  8  9");
    Console.WriteLine("___________________________________________________________________");
    for (int j = 0; j < 10; j++)
    {
        Console.Write($"{j}|");
        for (int k = 0; k < 10; k++)
        {
            Console.Write($"{temp_board[j, k]}");
        }
        Console.Write("  |");
        for (int k = 0; k < 10; k++)
        {
            Console.Write($"{ai_temp_board[j, k]}");
        }
        Console.WriteLine("");

    }
    player_turn();
    ai_turn();
    turn1_pass = true;
    if (player_hit == 18)
    {
        player_hit++;
    }
} while (player_hit < 19 && ai_hit < 19);

