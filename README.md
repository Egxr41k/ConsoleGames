# Neural Network for tic-tac-toe game.

has console (C#) and web (TS) interfaces, all logic located in TicTacToe.Core
## Table of Contents
- [Todo](#todo)
- [Install](#install)
- [Run](#run)
- [Docs](#docs)

## Todo
1. ~~Update Readme~~
2. ~~Add Web-interface~~
3. Bug fixing in TicTacToe.Core
4. Add game mode switcher

## Install
```
git clone https://github.com/Egxr41k/ConsoleTicTacToe.git
```
## Run
To start in the terminal, use the first command. If you want to start in the browser, use the second command.

```
cd TicTacToe.Console
cd TicTacToe.API
```
then, run the selected .net project

```
dotnet run
```
## Docs
class explanation in TicTacToe.Core:

1. Matrix - contains a matrix (two-dimensional array serving as a playing field) and static methods for working with it.
2. Game is the parent class for DeepLearning and MinAPI, it contains the methods and fields necessary for the game and the processes based on it.
3. DeepLearning - a class that implements the so-called deep learning using a cycle of automated neural network games with random moves without human intervention
  <details>
	  <summary>Deep learning explanation</summary>
	    Is just a wrapper over nn.Backpropagation. During each game, the neural network receives the response it needs for training, represented by the response variable.           This type of learning can be classified as supervised learning, although the classical dataset is not used
  </details>

4. NeuralNetwork - a neural network class, that contains methods for its use and training.
  <details>
	  <summary>NeuralNetwork structure explanation</summary>
	  the neural network consists of three methods representing its different parts
	  InputLayer
	  HiddenLayers
	  OutputLayer
	  technically, these layers do not exist, but there are arrays of neurons.
    1. InputNeurons - stores input neurons,
	  they are needed to transfer values to the neural network.
    2. HiddenNeurons - unlike InputNeurons, this array is two-dimensional
	  the second dimension is needed to mark the layers of neurons.
    3. OutputNeurons does not exist for the following reason:
	  the task in question requires output from the neural network
	  as two integers from 0 to 2 inclusive.
	  Due to the fact that the neural network operates with fractional numbers from 0 to 1
	  using two neurons representing indexes will not work.
    Therefore, the initialization of the network output is implemented by the OutputLayer method.
	  it finds the largest value on the last hidden layer
	  and writes its position into indices like this,
	  if the final value of the neurons of the last hidden layer
	  were written in a two-dimensional array (row and column)
  </details>

5. Neuron - contains a set of weights variables storing values the activation function and the derivative of the activation function, is a structural unit for the NeuralNetwork class

<details>
	<summary>notes:</summary>
  the position of the character playing is the coordinate in the matrix
  so for example the position in the center of the field will have indices 1 1,
  where the first index is the row number and the second is the column number
  (due to the fact that the count of array elements starts from 0
  first row/column respectively have index 0)
</details>

### ©Egxr41k Software 2023


