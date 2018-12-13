# Grammar 语法

本节使用扩展的 BNF 描述 IceKori 的形式语法。
```
# 节点
<Name> : 代表一个 IceKori 图形节点。
<name> : 一个中间表示。 // 并不实际存在对应的图形节点。
#Name[type] : 代表一个 C# 对象（如 int/float/string）, `[]` 内表示对应的 c# 类型。
@Name : 代表一个 c# 的枚举。

# 符号
(...) : 表示一个 IceKori 的内部结构展开。
{...} : 表示一个 c# 枚举的内部展开。

# 量词：
* ： 零个或更多。
+ ： 至少一个。
```
## Basics

```
<token> → <IceKoriString>
    | <IceKoriInt>
    | <IceKoriInt>
    | <IceKoriFloat>
    | <IceKoriBoolean>
    | <IceKoriObject>
    | <Error>

<IceKoriString> → (#Value[string])

<IceKoriInt> → (#Value[int])

<IceKoriFloat> → (#Value[float])

<IceKoriBoolean> → (#Value[bool])

<IceKoriObject> → (#Value[object])

<Error> -> (#Message[string])
```

## Expression

```
<Expression> → <BinaryExpression> 
    | <VariableGet> 
    | <GlobalVariableGet>
    | <token>

<BinaryExpression> → (@Operator <left> <right>)
@Operator {
    Add,
    Sub,
    Mul,
    Div,
    Mod,
    Concat,
    Less,
    LessEqual,
    Equal,
    MoreEqual,
    More,
    NotEqual,
    And,
    Or
}
<left> → <Expresion>
<right> → <Expresion>

<VariableGet> → (#Name[string])

<GlobalVariableGet> → (#Name[string])
```

## statement

```
<Statement> → <IfStatement>
    | <ForStatement>
    | <WhileStatement>
    | <Define>
    | <GlobalDefine>
    | <VariableUpdate>
    | <GlobalVariableUpdate>
    | <CommandCall>
    | <GlobalCommandCall>
    | <Display>
    | <DebugPrint>
    | <TryCatch>
    | <Throw>
    | <DoNothing>

<IfStatement> → (<condition> <consequence> <alternative>*)
<condition> → <Expression>
<consequence> → <Expression>*
<alternative> → <Expression>*

<ForStatement> → (#Count[int] <body>)
<body> → <Statement>*

<WhileStatement> → (<condition> <body>)

<value> → <Expression>

<Define> → (#Name[string] <value>)

<GobalDefine> → (#Name[string] <value>)

<VariableUpdate> → (#Name[string] <value>)

<GlobalVariableUpdate> → (#Name[string] <value>)

<CommandCall> → (#Name[string])

<GlobalCommandCall> → (#Name[string])

<Display> → (<value>)

<DebugPrint> → (<value>)

<TryCatch> → (<body> @Catch <rescue>)

@Catch {
    TypeError,
    ReferenceError,
    All
}

<Throw> → (<Error>)

<DoNothing> → ()
```

## Grammar

```
IceKori → <Statement>*
```