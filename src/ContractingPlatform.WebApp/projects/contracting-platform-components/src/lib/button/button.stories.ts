import type { Meta, StoryObj } from '@storybook/angular';
import { Button } from './button';

const meta: Meta<Button> = {
  title: 'Components/Button',
  component: Button,
  tags: ['autodocs'],
  argTypes: {
    variant: {
      control: 'select',
      options: ['primary', 'secondary', 'outlined', 'text'],
      description: 'The button variant',
    },
    size: {
      control: 'select',
      options: ['small', 'medium', 'large'],
      description: 'The button size',
    },
    disabled: {
      control: 'boolean',
      description: 'Whether the button is disabled',
    },
    fullWidth: {
      control: 'boolean',
      description: 'Whether the button takes full width',
    },
    icon: {
      control: 'text',
      description: 'Material icon name',
    },
    iconPosition: {
      control: 'select',
      options: ['left', 'right'],
      description: 'Position of the icon',
    },
  },
  render: (args) => ({
    props: args,
    template: `<lib-button [variant]="variant" [size]="size" [disabled]="disabled" [fullWidth]="fullWidth" [icon]="icon" [iconPosition]="iconPosition">Button</lib-button>`,
  }),
};

export default meta;
type Story = StoryObj<Button>;

export const Primary: Story = {
  args: {
    variant: 'primary',
    size: 'medium',
    disabled: false,
    fullWidth: false,
  },
};

export const Secondary: Story = {
  args: {
    variant: 'secondary',
    size: 'medium',
    disabled: false,
    fullWidth: false,
  },
};

export const Outlined: Story = {
  args: {
    variant: 'outlined',
    size: 'medium',
    disabled: false,
    fullWidth: false,
  },
};

export const Text: Story = {
  args: {
    variant: 'text',
    size: 'medium',
    disabled: false,
    fullWidth: false,
  },
};

export const WithIcon: Story = {
  args: {
    variant: 'primary',
    size: 'medium',
    icon: 'phone',
    iconPosition: 'left',
  },
};

export const Large: Story = {
  args: {
    variant: 'primary',
    size: 'large',
  },
};

export const Small: Story = {
  args: {
    variant: 'primary',
    size: 'small',
  },
};

export const FullWidth: Story = {
  args: {
    variant: 'primary',
    size: 'medium',
    fullWidth: true,
  },
};

export const Disabled: Story = {
  args: {
    variant: 'primary',
    size: 'medium',
    disabled: true,
  },
};
