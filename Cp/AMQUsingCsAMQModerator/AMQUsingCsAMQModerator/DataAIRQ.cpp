#include "AMQDatas.h"

ActiveMQCData::DataAIRQ::DataAIRQ() {
}

ActiveMQCData::DataAIRQ::DataAIRQ(std::string data) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRQ::DataAIRQ(Json::Value data) {
	MagicSetValue(data);
}

ActiveMQCData::DataAIRQ::~DataAIRQ() {
}

std::string ActiveMQCData::DataAIRQ::Tostring() {
	Json::StyledWriter writer;
	std::string value = writer.write(ToJson());
	return value;
}

Json::Value ActiveMQCData::DataAIRQ::ToJson() {
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
	value[NAME_OF(SUB_JUDGE_SERVICE_TYPE)] = SUB_JUDGE_SERVICE_TYPE;
	value[NAME_OF(IMAGE_PATH_LIST)] = ActiveMQCData::JsonAssist::StringArrayToJsonArray(IMAGE_PATH_LIST);
	value[NAME_OF(RESULT_INFO)] = RESULT_INFO;
	return value;
}

bool ActiveMQCData::DataAIRQ::MagicSetValue(std::string data) {
	Json::Value receiveData;
	Json::Reader reader;
	bool parsingSuccessful = reader.parse(data, receiveData);
	if (!parsingSuccessful) {
		return false;
	}
	return MagicSetValue(receiveData);
}

bool ActiveMQCData::DataAIRQ::MagicSetValue(Json::Value data) {
	Version = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(Version));
	MessageName = ActiveMQCData::JsonAssist::ParsingJson(data, NAME_OF(MessageName));
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
	IMAGE_PATH_LIST = ActiveMQCData::JsonAssist::JsonArrayToStringArray(data[NAME_OF(IMAGE_PATH_LIST)]);
	return true;
}