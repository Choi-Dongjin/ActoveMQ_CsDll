#include "AMQModerator.h"

using namespace ActiveMQC;

AMQModerator::AMQModerator(const char* brokerUri, const char* destinationName)
    : _brokerURL(brokerUri), _destinationName(destinationName) {

    _hActiveMQModerator = LoadLibraryA("AMQModerator.dll");

    // Load functions
    _pMQBrokerURLIsLive = (bool (*)(char*))(GetProcAddress(_hActiveMQModerator, "BrokerUriIsLive"));
    if (_pMQBrokerURLIsLive == 0) {
        const char* log = "ActiveMQ BrokerUrlIsLive Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pMQInitialize = (bool (*)(char*, char*))(GetProcAddress(_hActiveMQModerator, "Initialize"));
    if (_pMQInitialize == 0) {
        const char* log = "ActiveMQ Initialize Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pMQIsConnected = (bool (*)(bool))(GetProcAddress(_hActiveMQModerator, "IsConnected"));
    if (_pMQIsConnected == 0) {
        const char* log = "ActiveMQ IsConnected Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pMQSendMessage = (bool (*)(char*))(GetProcAddress(_hActiveMQModerator, "SendMessage"));
    if (_pMQSendMessage == 0) {
        const char* log = "ActiveMQ SendMessage Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pMQReceiveMessage = (char* (*)(bool))(GetProcAddress(_hActiveMQModerator, "ReceiveMessage"));
    if (_pMQReceiveMessage == 0) {
        const char* log = "ActiveMQ ReceiveMessage Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pMQMorderatorDispose = (bool (*)(bool))(GetProcAddress(_hActiveMQModerator, "MorderatorDispose"));
    if (_pMQMorderatorDispose == 0) {
        const char* log = "ActiveMQ MorderatorDispose Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }

    _pTESTInitSendMess_AIRQ = (bool (*)(bool))(GetProcAddress(_hActiveMQModerator, "TESTInitSendMess_AIRQ"));
    if (_pTESTInitSendMess_AIRQ == 0) {
        const char* log = "ActiveMQ TESTInitSendMess_AIRQ Function Pointer Link(GetProcAddress) False";
        std::cout << log << std::endl;
        throw log;
    }
}

AMQModerator::~AMQModerator() {
    // Unload the library
    (*_pMQMorderatorDispose)(true);
    FreeLibrary(_hActiveMQModerator);
}

bool AMQModerator::BrokerUriIsLive(char* url) {
    return (*_pMQBrokerURLIsLive)(url);
}

bool AMQModerator::Initialize() {
    return (*_pMQInitialize)((char*)_brokerURL, (char*)_destinationName);
}

bool AMQModerator::IsConnected() {
    return (*_pMQIsConnected)(true);
}

bool AMQModerator::MQSendMessage(char* message) {
    return (*_pMQSendMessage)(message);
}

/// <summary>
/// 데이터 수신
/// 수신 실패 
///     1 : False Value
///     2 : Main.consumer is not Init
///     3 : Null mess
/// </summary>
/// <returns> 수신 메시지 </returns>
char* AMQModerator::ReceiveMessage() {
    return (*_pMQReceiveMessage)(true);
}

bool AMQModerator::MQMorderatorDispose() {
    return (*_pMQMorderatorDispose)(true);
}

bool AMQModerator::TESTInitSendMess_AIRQ() {
    return (*_pTESTInitSendMess_AIRQ)(true);
}