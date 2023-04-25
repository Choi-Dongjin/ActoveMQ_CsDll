#include "AMQDatas.h"

ActiveMQCData::DataAIRS::DataAIRS() {
}

ActiveMQCData::DataAIRS::DataAIRS(std::string data) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRS::DataAIRS(Json::Value data) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRS::DataAIRS(DataAIRQ data) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRS::DataAIRS(DataAIRQ data, std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime) : JUDGE_PROGRAM_ID(judgeProgramID), RESULT(result), ERROR_CODE(errorCode), ERROR_MESSAGE(errorMessage), WORK_START_DATE(workStartDate), WORK_TIME(workTime), WAIT_TIME(waitTime) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRS::~DataAIRS() {
}

void ActiveMQCData::DataAIRS::SetResultInfo(ActiveMQCData::DataAIRSResultInfo dataAIRSResultInfo) {
	RESULT_INFO = dataAIRSResultInfo;
}

void ActiveMQCData::DataAIRS::SetIniData(std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime) {
	JUDGE_PROGRAM_ID = judgeProgramID;
	RESULT = result;
	ERROR_CODE = errorCode;
	ERROR_MESSAGE = errorMessage;
	WORK_START_DATE = workStartDate;
	WORK_TIME = workTime;
	WAIT_TIME = waitTime;
}

std::string ActiveMQCData::DataAIRS::Tostring() {
	Json::StyledWriter writer;
	std::string value = writer.write(ToJson());
	return value;
}

Json::Value ActiveMQCData::DataAIRS::ToJson() {
	Json::Value value;
	value[NAME_OF(Version)] = Version;
	value[NAME_OF(MessageName)] = MessageName;
	value[NAME_OF(Description)] = Description;
	value[NAME_OF(ConsumerAddr)] = ConsumerAddr;
	value[NAME_OF(ConsumerDestinationType)] = ConsumerDestinationType;
	value[NAME_OF(ProducerAddr)] = ProducerAddr;
	value[NAME_OF(ProducerDestinationType)] = ProducerDestinationType;
	value[NAME_OF(TransID)] = TransID;
	value[NAME_OF(FACILITY)] = FACILITY;
	value[NAME_OF(PRODUCT)] = PRODUCT;
	value[NAME_OF(MACHINE_ID)] = MACHINE_ID;
	value[NAME_OF(PROCESS_CODE)] = PROCESS_CODE;
	value[NAME_OF(LOT_ID)] = LOT_ID;
	value[NAME_OF(PANEL_ID)] = PANEL_ID;
	value[NAME_OF(MODULE_ID)] = MODULE_ID;
	value[NAME_OF(JUDGE_SERVICE_TYPE)] = JUDGE_SERVICE_TYPE;
	value[NAME_OF(SUB_JUDGE_SERVICE_TYPE)] = SUB_JUDGE_SERVICE_TYPE;
	value[NAME_OF(JUDGE_PROGRAM_ID)] = JUDGE_PROGRAM_ID;
	value[NAME_OF(RESULT)] = RESULT;
	value[NAME_OF(ERROR_CODE)] = ERROR_CODE;
	value[NAME_OF(ERROR_MESSAGE)] = ERROR_MESSAGE;
	value[NAME_OF(WORK_START_DATE)] = WORK_START_DATE;
	value[NAME_OF(WORK_TIME)] = WORK_TIME;
	value[NAME_OF(WAIT_TIME)] = WAIT_TIME;
	value[NAME_OF(RESULT_INFO)] = RESULT_INFO.ToJson();
	return value;
}

bool ActiveMQCData::DataAIRS::MagicSetValue(std::string data)
{
	Json::Value receiveData;
	Json::Reader reader;
	bool parsingSuccessful = reader.parse(data, receiveData);
	if (!parsingSuccessful) {
		return false;
	}
	return MagicSetValue(receiveData);
	return true;
}

bool ActiveMQCData::DataAIRS::MagicSetValue(Json::Value data)
{
	Version = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(Version));
	MessageName = "AIRS";
	Description = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(Description));
	ConsumerAddr = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(ConsumerAddr));
	ConsumerDestinationType = ActiveMQCData::JsonAssist::ParsingJsonToInt(data, NAME_OF(ConsumerDestinationType));
	ProducerAddr = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(ProducerAddr));
	ProducerDestinationType = ActiveMQCData::JsonAssist::ParsingJsonToInt(data, NAME_OF(ProducerDestinationType));
	TransID = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(TransID));
	FACILITY = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(FACILITY));
	PRODUCT = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(PRODUCT));
	MACHINE_ID = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(MACHINE_ID));
	PROCESS_CODE = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(PROCESS_CODE));
	LOT_ID = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(LOT_ID));
	PANEL_ID = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(PANEL_ID));
	MODULE_ID = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(MODULE_ID));
	JUDGE_SERVICE_TYPE = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(JUDGE_SERVICE_TYPE));
	SUB_JUDGE_SERVICE_TYPE = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(SUB_JUDGE_SERVICE_TYPE));
	return true;
}

bool ActiveMQCData::DataAIRS::MagicSetValue(ActiveMQCData::DataAIRQ data)
{
	Version = data.Version;
	MessageName = "AIRS";
	Description = data.Description;
	ConsumerAddr = data.ProducerAddr;
	ConsumerDestinationType = data.ProducerDestinationType;
	ProducerAddr = data.ConsumerAddr;
	ProducerDestinationType = data.ConsumerDestinationType;
	TransID = data.TransID;
	FACILITY = data.FACILITY;
	PRODUCT = data.PRODUCT;
	MACHINE_ID = data.MACHINE_ID;
	PROCESS_CODE = data.PROCESS_CODE;
	LOT_ID = data.LOT_ID;
	PANEL_ID = data.PANEL_ID;
	MODULE_ID = data.MODULE_ID;
	JUDGE_SERVICE_TYPE = data.JUDGE_SERVICE_TYPE;
	SUB_JUDGE_SERVICE_TYPE = data.SUB_JUDGE_SERVICE_TYPE;
	return true;
}

bool ActiveMQCData::DataAIRS::MagicSetValue(ActiveMQCData::DataAIRQ data, std::string judgeProgramID, std::string result, std::string errorCode, std::string errorMessage, std::string workStartDate, std::string workTime, std::string waitTime)
{
	Version = data.Version;
	MessageName = "AIRS";
	Description = data.Description;
	ConsumerAddr = data.ProducerAddr;
	ConsumerDestinationType = data.ProducerDestinationType;
	ProducerAddr = data.ConsumerAddr;
	ProducerDestinationType = data.ConsumerDestinationType;
	TransID = data.TransID;
	FACILITY = data.FACILITY;
	PRODUCT = data.PRODUCT;
	MACHINE_ID = data.MACHINE_ID;
	PROCESS_CODE = data.PROCESS_CODE;
	LOT_ID = data.LOT_ID;
	PANEL_ID = data.PANEL_ID;
	MODULE_ID = data.MODULE_ID;
	JUDGE_SERVICE_TYPE = data.JUDGE_SERVICE_TYPE;
	SUB_JUDGE_SERVICE_TYPE = data.SUB_JUDGE_SERVICE_TYPE;
	SetIniData(judgeProgramID, result, errorCode, errorMessage, workStartDate, workTime, waitTime);
	return true;
}