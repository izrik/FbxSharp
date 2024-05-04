using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FbxSharp
{
    public enum TokenType
    {
        None,
        Unknown,

        Comment,
        Star,
        OpenBrace,
        CloseBrace,
        Name,
        Number,
        Colon,
        Comma,
        String,
        Whitespace,
    }
}

/*



array = '*' number block;

block = '{' object* '}';

<comment> comment = ';' [^\n]* '\n';

file = object+;

<token> name = [\l_] [\l\d_]*;

<token> number = [+-]? [\d]+ ( '.' [\d]+ )?;

object = name ':' ( ( value ( ',' value )* )? block | value ( ',' value )* );

<token> string = '"' [^"]* '"';

value = ( number | string | array );


*/