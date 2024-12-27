import React from "react";
import { Form, Input, Button, Radio, Image, Flex } from "antd";
import { noop } from "antd/es/_util/warning";
const { TextArea } = Input;

function DecorationForm({ handleSubmit }) {
  const [form] = Form.useForm();

  const handleFinish = (values) => {
    handleSubmit(values);
    form.resetFields();
  };

  return (
    <Form form={form} onFinish={handleFinish} layout="vertical">
      <Form.Item
        name="author"
        label="Author"
        rules={[
          {
            required: true,
            message: "Please input your name",
          },
        ]}
      >
        <Input showCount maxLength={100} />
      </Form.Item>

      <Form.Item
        name="message"
        label="Message"
        rules={[{ required: true, message: "Please input the your message!" }]}
      >
        <TextArea
          showCount
          maxLength={300}
          autoSize={{
            minRows: 3,
            maxRows: 6,
          }}
        />
      </Form.Item>

      <Form.Item
        name="type"
        label="Type"
        rules={[{ required: true, message: "Please select the type!" }]}
      >
        <Flex vertical gap="middle">
          <Radio.Group size="large">
            <Radio.Button value="red-ball" style={{ height: "80px" }}>
              <Image
                width={75}
                height={75}
                src="red-ball.png"
                preview={false}
              />
            </Radio.Button>

            <Radio.Button value="blue-ball" style={{ height: "80px" }}>
              <Image
                width={75}
                height={75}
                src="blue-ball.png"
                preview={false}
              />
            </Radio.Button>

            <Radio.Button value="bell" style={{ height: "80px" }}>
              <Image width={75} height={75} src="bell.png" preview={false} />
            </Radio.Button>

            <Radio.Button value="wreath" style={{ height: "80px" }}>
              <Image width={75} height={75} src="wreath.png" preview={false} />
            </Radio.Button>
          </Radio.Group>
        </Flex>
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
}

export default DecorationForm;
