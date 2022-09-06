/// <reference path="../scripts/angular.js" />
var app = angular.module("funcionarioApp", []);

app.controller("funcionarioCtrl", function ($scope, $http) {

    function OpenModal() {
        $('#editEmployeeModal').modal('show');
    }
    TodosFuncionarios();
    GetSetores();
    function TodosFuncionarios() {
        $http.get('/home/GetFuncionarios/').then(function (result) {
            $scope.funcionarios = result.data;
            console.log($scope.funcionarios);
        }, function (error) {
            return error;
        });
    }

    function GetSetores() {
        $http.get('/home/GetSetores/').then(function (result) {
            $scope.setores = result.data;
        }, function (error) {
            return error;
        });
    }



    $scope.GetFuncionario = function (func) {

        var response = $http({
            method: 'GET',
            url: 'Home/GetById',
            params: {
                id: func.FuncionarioId
            },
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        }).then(function (response) {
            if (response.data) {

                $scope.NomeCompleto = response.data.NomeCompleto;
                $scope.NomeSocial = response.data.NomeSocial;
                $scope.RG = response.data.RG;
                $scope.CPF = response.data.CPF;
                $scope.DataNascimento = response.data.DataNascimento;
                $scope.Logradouro = response.data.Logradouro;
                $scope.Numero = response.data.Numero;
                $scope.Cidade = response.data.Cidade;
                $scope.CEP = response.data.CEP;
                $scope.Complemento = response.data.Complemento;
                $scope.Estado = response.data.Estado;
                $scope.TelefoneCelular = response.data.TelefoneCelular;
                $scope.TelefoneResidencial = response.data.TelefoneResidencial;
                $scope.Cargo = {};
                $scope.Cargo.Descricao = response.data.Cargo.Descricao;
                $scope.Cargo.Salario = response.data.Cargo.Salario;
                $scope.Cargo.DataInicio = response.data.Cargo.DataInicio;
                $scope.Cargo.DataEncerramento = response.data.Cargo.DataEncerramento;
                $scope.Cargo.Setor = {};
                $scope.Cargo.Setor.SetorId = response.data.Cargo.Setor.SetorId;


                $('#funcionarioId').val($scope.funcionarioId);
                $('#NomeCompleto').val($scope.NomeCompleto);
                $('#NomeSocial').val($scope.NomeSocial);
                $('#RG').val($scope.RG);
                $('#CPF').val($scope.CPF);
                $('#DataNascimento').val($scope.DataNascimento);
                $('#Logradouro').val($scope.Logradouro);
                $('#Numero').val($scope.Numero);
                $('#Cidade').val($scope.Cidade);
                $('#CEP').val($scope.CEP);
                $('#Complemento').val($scope.Complemento);
                $('#Estado').val($scope.Estado);
                $('#TelefoneCelular').val($scope.TelefoneCelular);
                $('#TelefoneResidencial').val($scope.TelefoneResidencial);
                $('#CargoDescricao').val($scope.Cargo.Descricao);
                $('#CargoSalario').val($scope.Cargo.Salario);
                $('#CargoDataInicio').val($scope.Cargo.DataInicio);
                $('#CargoDataEncerramento').val($scope.Cargo.DataEncerramento);
                $('#SetorId').val($scope.Cargo.Setor.SetorId);

                OpenModal();
        }, function (error) {
            return error
        });


        return response;
    }

    $scope.IncluiFuncionario = function () {
        debugger;
        var stObject = {
            NomeCompleto: $scope.NomeCompleto,
            NomeSocial: $scope.NomeSocial,
            RG: $scope.RG,
            CPF: $scope.CPF,
            DataNascimento: $scope.DataNascimento,
            Logradouro: $scope.Logradouro,
            Numero: $scope.Numero,
            Cidade: $scope.Cidade,
            CEP: $scope.CEP,
            Complemento: $scope.Complemento,
            Estado: $scope.Estado,
            TelefoneCelular: $scope.TelefoneCelular,
            TelefoneResidencial: $scope.TelefoneResidencial,
            Cargo: {
                Descricao: $scope.Cargo.Descricao,
                Salario: $scope.Cargo.Salario,
                DataInicio: $scope.Cargo.DataInicio,
                DataEncerramento: $scope.Cargo.DataEncerramento,
                Setor: {
                    SetorId: $scope.Cargo.Setor.SetorId
                }
            },

        };

        var response = $http({
            method: 'POST',
            url: 'home/AdicionarFuncionario',
            data: JSON.stringify(stObject),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8'
        }).then(function (sucess) {
            TodosFuncionarios();
            console.log('CARREGA TODOS');
        });
        return response;
    }


});




